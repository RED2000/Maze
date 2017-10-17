using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Engine
{
  public interface IGameStateSerializer
  {
    string SerializeState();

    GameState DeserializeState(string state);
  }
}
