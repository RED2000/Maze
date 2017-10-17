using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Engine
{
  public interface IMazeGameController
  {
    bool TryUp();
    bool TryDown();
    bool TryLeft();
    bool TryRight();

    Tuple<int, int>[] Solve();

    bool IsWin();

    GameState State { get; }
  }
}
