using System;
using System.Collections.Generic;
using System.Drawing;
using Maze.Engine;
using System.Linq;

namespace Maze
{
  public class MazeViewer
  {
    /// <summary>
    /// Render the current maze as a bitmap image
    /// </summary>
    /// <param name="node"></param>
    /// <param name="sz"></param>
    /// <param name="playerPos"></param>
    /// <param name="tace"></param>
    /// <returns></returns>
    public Bitmap Visualize(List<List<Node>> nodes, Tuple<int, int> playerPos = null, IEnumerable<Tuple<int, int>> trace = null)
    {
      Size sz = new Size(8, 8);
      Bitmap b = new Bitmap(nodes.Count * sz.Width + 1, nodes[0].Count * sz.Height + 1);
      using (Graphics g = Graphics.FromImage(b))
      {
        for (int x = 0; x < nodes.Count; x++)
        {
          for (int y = 0; y < nodes[x].Count; y++)
          {
            if (!nodes[x][y].GetWall(0))
            {
              //Up
              g.DrawLine(Pens.Black, sz.Height * x, sz.Width * y, sz.Height * (x + 1), sz.Width * y);
            }
            if (!nodes[x][y].GetWall(3))
            {
              //Left
              g.DrawLine(Pens.Black, sz.Height * x, sz.Width * y, sz.Height * x, sz.Width * (y + 1));
            }
            if (!nodes[x][y].GetWall(1))
            {
              //Right
              g.DrawLine(Pens.Black, sz.Height * (x + 1), sz.Width * y, sz.Height * (x + 1), sz.Width * (y + 1));
            }
            if (!nodes[x][y].GetWall(2))
            {
              //Down
              g.DrawLine(Pens.Black, sz.Height * x, sz.Width * (y + 1), sz.Height * (x + 1), sz.Width * (y + 1));
            }
            if (nodes[x][y].IsEnd)
            {
              g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Blue)), sz.Height * x, sz.Width * y, sz.Width, sz.Height);
            }
            if (trace != null && trace.Where(t => t.Item1 == x && t.Item2 == y).Count() != 0)
            {
              g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Green)), sz.Height * x, sz.Width * y, sz.Width, sz.Height);
            }
            if (playerPos != null && playerPos.Item1 == x && playerPos.Item2 == y)
            {
              g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Red)), sz.Height * x, sz.Width * y, sz.Width, sz.Height);
            }
          }
        }
      };
      return b;
    }
  }
}
