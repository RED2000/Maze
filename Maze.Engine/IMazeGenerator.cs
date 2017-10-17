using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Engine
{
  public interface IMazeGenerator : IDisposable
  {
    void Generate();

    List<List<Node>> Nodes { get; }
  }
}
