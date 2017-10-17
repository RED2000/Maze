using System;
using System.Windows.Forms;
using System.Threading;
using Maze;
using Maze.Engine;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MazeGen
{
  public partial class frmMain : Form
  {
    private MazeViewer viewer = new MazeViewer();
    private IMazeGenerator maze;
    private IMazeGameController gameController;

    public frmMain()
    {
      InitializeComponent();

      this.KeyPreview = true;
      this.KeyPress += new KeyPressEventHandler(frmMain_KeyPress);
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      txtHeight.Text = "10";
      txtWidth.Text = "10";
    }

    void ToggleButtonState(bool isEnabled)
    {
      txtHeight.Enabled = isEnabled;
      txtHeight.Enabled = isEnabled;
      btnGenerate.Enabled = isEnabled;
    }

    private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == 'w' || e.KeyChar == 'W')
        UpClick();
      else if (e.KeyChar == 's' || e.KeyChar == 'S')
        DownClick();
      else if (e.KeyChar == 'a' || e.KeyChar == 'A')
        LeftClick();
      else if (e.KeyChar == 'd' || e.KeyChar == 'D')
        RightClick();
    }

    private void btnGenerate_Click(object sender, EventArgs e)
    {
      maze = new MazeGenerator(Convert.ToInt32(txtHeight.Text), Convert.ToInt32(txtHeight.Text));

      ToggleButtonState(false);

      new Thread(delegate ()
      {
        using (maze)
        {
          maze.Generate();

          gameController = new MazeGameController(maze.Nodes);

          picVisual.Invoke((MethodInvoker)delegate ()
          {
            var currentMaze = viewer.Visualize(gameController.State.Nodes, gameController.State.PlayerPos);

            picVisual.Image = currentMaze;

            ToggleButtonState(true);
          });

          lblWin.Invoke((MethodInvoker)delegate ()
          {
            this.lblWin.Visible = gameController.IsWin();
          });
        }

      })
      { IsBackground = true }.Start();
    }

    private void btnUp_Click(object sender, EventArgs e)
    {
      this.UpClick();
    }

    private void btnDown_Click(object sender, EventArgs e)
    {
      this.DownClick();
    }

    private void btnLeft_Click(object sender, EventArgs e)
    {
      this.LeftClick();
    }

    private void btnRight_Click(object sender, EventArgs e)
    {
      this.RightClick();
    }
    
    private void UpClick()
    {
      if (gameController.TryUp())
        this.UpdatePlayerPos();
    }

    private void DownClick()
    {
      if (gameController.TryDown())
        this.UpdatePlayerPos();
    }

    private void LeftClick()
    {
      if (gameController.TryLeft())
        this.UpdatePlayerPos();
    }

    private void RightClick()
    {
      if (gameController.TryRight())
        this.UpdatePlayerPos();
    }

    private void UpdatePlayerPos(IEnumerable<Tuple<int, int>> trace = null)
    {
      new Thread(delegate ()
      {
        using (maze)
        {
          picVisual.Invoke((MethodInvoker)delegate ()
          {
            picVisual.Image = viewer.Visualize(gameController.State.Nodes, gameController.State.PlayerPos, trace);
          });

          lblWin.Invoke((MethodInvoker)delegate ()
          {
              this.lblWin.Visible = gameController.IsWin();            
          });
        }
      })
      { IsBackground = true }.Start();
    }

    private void btnSolve_Click(object sender, EventArgs e)
    {
      var trace = gameController.Solve();
      var breadcrumbs = new List<Tuple<int, int>>();

      UpdatePlayerPos(trace);
    }
  }
}