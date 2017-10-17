using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze.Engine
{
  public class MazeGameController : IMazeGameController, IGameStateSerializer, IDisposable
  {
    public MazeGameController(string state)
    {
      this.DeserializeState(state);
    }

    public MazeGameController(List<List<Node>> nodes)
    {
      this.State = new GameState();
      this.State.Nodes = nodes;
    }

    public GameState State { get; private set; } = new GameState();

    public bool TryUp()
    {
      var playerNode = this.State.Nodes[this.State.PlayerPos.Item1][this.State.PlayerPos.Item2];

      if (playerNode.GetWall(0))
      {
        this.State.PlayerPos = new Tuple<int, int>(this.State.PlayerPos.Item1, this.State.PlayerPos.Item2 - 1);

        return true;
      }
      else
        return false;
    }

    public bool TryDown()
    {
      var playerNode = this.State.Nodes[this.State.PlayerPos.Item1][this.State.PlayerPos.Item2];

      if (playerNode.GetWall(2))
      {
        this.State.PlayerPos = new Tuple<int, int>(this.State.PlayerPos.Item1, this.State.PlayerPos.Item2 + 1);
        return true;
      }
      else
        return false;
    }

    public bool TryLeft()
    {
      var playerNode = this.State.Nodes[this.State.PlayerPos.Item1][this.State.PlayerPos.Item2];

      if (playerNode.GetWall(3))
      {
        this.State.PlayerPos = new Tuple<int, int>(this.State.PlayerPos.Item1 - 1, this.State.PlayerPos.Item2);
        return true;
      }
      else
        return false;
    }

    public bool TryRight()
    {
      var playerNode = this.State.Nodes[this.State.PlayerPos.Item1][this.State.PlayerPos.Item2];

      if (playerNode.GetWall(1))
      {
        this.State.PlayerPos = new Tuple<int, int>(this.State.PlayerPos.Item1 + 1, this.State.PlayerPos.Item2);
        return true;
      }
      else
        return false;
    }

    public Tuple<int, int>[] Solve()
    {
      var deadEnds = new List<Node>();
      var currentNode = this.State.Nodes[this.State.PlayerPos.Item1][this.State.PlayerPos.Item2];
      Node lastNode = null;
      var lastPosition = this.State.PlayerPos;
      var solved = false;
      var playPos = new Stack<Tuple<int, int>>();

      while (!solved)
      {
        Node nextNode = null;

        if (nextNode == null && currentNode.GetWall(0) && this.State.PlayerPos.Item2 != 0)
        {
          // We can move up
          nextNode = this.State.Nodes[this.State.PlayerPos.Item1][this.State.PlayerPos.Item2 - 1];

          if (!deadEnds.Contains(nextNode) && (lastNode == null || lastNode != nextNode))
            this.State.PlayerPos = new Tuple<int, int>(this.State.PlayerPos.Item1, this.State.PlayerPos.Item2 - 1);
          else
            nextNode = null;
        }

        if (nextNode == null && currentNode.GetWall(1) && !(this.State.PlayerPos.Item1 + 1 == this.State.Nodes.Count))
        {
          // We can move right
          nextNode = this.State.Nodes[this.State.PlayerPos.Item1 + 1][this.State.PlayerPos.Item2];

          if (!deadEnds.Contains(nextNode) && (lastNode == null || lastNode != nextNode))
            this.State.PlayerPos = new Tuple<int, int>(this.State.PlayerPos.Item1 + 1, this.State.PlayerPos.Item2);
          else
            nextNode = null;
        }

        if (nextNode == null && currentNode.GetWall(2) && !(this.State.PlayerPos.Item2 + 1 == this.State.Nodes[this.State.PlayerPos.Item1].Count))
        {
          // We can move down
          nextNode = this.State.Nodes[this.State.PlayerPos.Item1][this.State.PlayerPos.Item2 + 1];

          if (!deadEnds.Contains(nextNode) && (lastNode == null || lastNode != nextNode))          
            this.State.PlayerPos = new Tuple<int, int>(this.State.PlayerPos.Item1, this.State.PlayerPos.Item2 + 1);
          else
            nextNode = null;
        }

        if (nextNode == null && currentNode.GetWall(3) && this.State.PlayerPos.Item1 != 0)
        {
          // We can move left
          nextNode = this.State.Nodes[this.State.PlayerPos.Item1 - 1][this.State.PlayerPos.Item2];

          if (!deadEnds.Contains(nextNode) && (lastNode == null || lastNode != nextNode))          
            this.State.PlayerPos = new Tuple<int, int>(this.State.PlayerPos.Item1 - 1, this.State.PlayerPos.Item2);
          else
            nextNode = null;
        }

        if (nextNode == null || nextNode == lastNode)
        {
          // We can't move or have gone back a step so register a deadend.
          deadEnds.Add(currentNode);

          this.State.PlayerPos = playPos.Count() == 0 ? new Tuple<int, int>(5, 5) : playPos.Pop();
          currentNode = lastNode;
        }
        else
        {
          // We have a next node and updated player position

          lastPosition = this.State.PlayerPos;
          playPos.Push(this.State.PlayerPos);
          lastNode = currentNode;
          currentNode = nextNode;
        }
        
        solved = currentNode.IsEnd;
      }
    
      return playPos.ToArray();
    }

    public bool IsWin()
    {
      var currentNode = this.State.Nodes[this.State.PlayerPos.Item1][this.State.PlayerPos.Item2];

      return currentNode.IsEnd;
    }

    public string SerializeState()
    {
      var settings = new JsonSerializerSettings()
      {
        ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
        PreserveReferencesHandling = PreserveReferencesHandling.Objects
      };

      var jsonString = JsonConvert.SerializeObject(this.State, settings);

      return jsonString;
    }

    public GameState DeserializeState(string state)
    {
      this.State = JsonConvert.DeserializeObject<GameState>(state);

      return this.State;
    }

    public void Dispose()
    {
      this.State = null;
    }

    protected virtual void Dispose(bool isDisposing)
    {
      if (isDisposing)
      {
        Dispose();
      }
    }
  }
}
