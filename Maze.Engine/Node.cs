using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace Maze.Engine
{  
  public class Node
  {
    private bool isEnd;
    private const int count = 4;
    private Node down;
    private Node up;
    private Node right;
    private Node left;

    /// <summary>
    /// Status of the four wall
    /// 0 = wall
    /// 1 = no wall
    ///  ____________________
    /// |Left|Down|Right| Up |
    /// |_8__|_4__|__2__|_0__|
    /// </summary>
    private int wall = 0;

    /// <summary>
    /// Mark the wall as missing
    /// </summary>
    /// <param name="index">Up = 0 Left = 1 Down = 2 Right = 3</param>
    public void UnWall(int index)
    {
      wall |= 1 << index;
    }

    /// <summary>
    /// Get a wall's status
    /// </summary>
    /// <param name="index"></param>
    /// <returns>True = Wall destroyed </returns>
    public bool GetWall(int index)
    {
      return (wall & (1 << index)) == (1 << index);
    }

    /// <summary>
    /// Mark the wall as missing
    /// </summary>
    /// <param name="index"></param>
    public void SetWall(int index)
    {
      wall &= ~(1 << index);
    }

    public Node this[int index]
    {
      get
      {
        return SwitchNodeProp(index);
      }
      set
      {
        SwitchNodeProp(index, value);
      }
    }

    private Node SwitchNodeProp(int index, Node value = null)
    {
      switch (index)
      {
        case 0:
          return ReturnNodeProp(ref up, value);
        case 1:
          return ReturnNodeProp(ref right, value);
        case 2:
          return ReturnNodeProp(ref down, value);
        case 3:
          return ReturnNodeProp(ref left, value);
      }

      return null;
    }
    private Node ReturnNodeProp(ref Node prop, Node value = null)
    {
      if (value == null)
      {
        return prop;
      }
      else
      {
        prop = value;
        return null;
      }
    }

    public Node Left
    {
      get
      {
        return left;
      }
      set
      {
        left = value;
      }
    }
    public Node Right
    {
      get
      {
        return right;
      }
      set
      {
        right = value;
      }
    }
    public Node Up
    {
      get
      {
        return up;
      }
      set
      {
        up = value;
      }
    }
    public Node Down
    {
      get
      {
        return down;
      }
      set
      {
        down = value;
      }
    }
    public int Count
    {
      get
      {
        return count;
      }
    }
    public int Wall
    {
      get
      {
        return wall;
      }
      set
      {
        wall = value;
      }
    }
    public bool IsEnd
    {
      get
      {
        return isEnd;
      }
      set
      {
        isEnd = value;
      }
    }
  }
}
