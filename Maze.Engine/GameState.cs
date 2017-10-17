using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Engine
{
  public class GameState
  {
    public List<List<Node>> Nodes { get; set; }
    public Tuple<int, int> PlayerPos { get; set; } = new Tuple<int, int>(5, 5);
  }
}
