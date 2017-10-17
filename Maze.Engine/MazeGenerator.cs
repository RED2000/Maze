using System;
using System.Collections.Generic;

namespace Maze.Engine
{
  /// <summary>
  /// Recursive Backtracking - Maze Generation
  /// </summary>
  public class MazeGenerator : IMazeGenerator
  {
    public List<List<Node>> Nodes { get; private set; } = new List<List<Node>>();

    public MazeGenerator(List<List<Node>> nodes)
    {
      this.Nodes = nodes;
    }

    /// <summary>
    /// Initialize a new 2d array of nodes
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public MazeGenerator(int width, int height)
    {
      for (int x = 0; x < width; x++)
      {
        List<Node> nX = new List<Node>();
        for (int y = 0; y < height; y++)
        {
          Node nY = new Node();

          if (y > 0)
          {
            nY.Up = nX[y - 1];
            nX[y - 1].Down = nY;
          }
          if (x > 0)
          {
            nY.Left = Nodes[x - 1][y];
            Nodes[x - 1][y].Right = nY;
          }
          nX.Add(nY);
        }
        Nodes.Add(nX);
      }
    }

    public void Generate()
    {
      int visitedCount = 1;
      int total = this.Nodes.Count * this.Nodes[0].Count;
      Stack<Node> visitedCell = new Stack<Node>();

      Random r = new Random();
      Node current = this.Nodes[(int)(r.NextDouble() * this.Nodes.Count * 10) % this.Nodes.Count][(int)(r.NextDouble() * this.Nodes[0].Count * 10) % this.Nodes.Count];
      current.IsEnd = true;

      while (visitedCount < total)
      {
        //List all available neighbour cells
        List<Node> readyNeighbourCells = new List<Node>();
        //Store the index of the neighbour cells
        List<int> readyNeighbourCellsIndex = new List<int>();
        for (int i = 0; i < current.Count; i++)
        {
          if (current[i] != null && current[i].Wall == 0)
          {
            readyNeighbourCells.Add(current[i]);
            readyNeighbourCellsIndex.Add(i);
          }

        }
        //no cells found
        if (readyNeighbourCells.Count == 0)
        {
          current = visitedCell.Pop();
          continue;
        }

        //Random select a cell
        int randIndex = (int)(r.NextDouble() * 10) % readyNeighbourCells.Count;
        int index = readyNeighbourCellsIndex[randIndex];
        Node neighbour = readyNeighbourCells[randIndex];

        // Knock the wall
        // 0-2 1-3
        current.UnWall(index);
        neighbour.UnWall((index + 2) % 4);
        visitedCell.Push(neighbour);
        current = neighbour;
        visitedCount++;
      }
    }

    public void Dispose()
    {
      Nodes = null;
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
