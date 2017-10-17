using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using Maze.Engine;

namespace Maze.Tests
{
  [TestClass]
  public class MazeTests
  {
    [TestMethod]
    public void GenerateMaze()
    {
      var mazeGenerator = new MazeGenerator(10, 10);

      mazeGenerator.Generate();

      Assert.AreEqual(10, mazeGenerator.Nodes.Count);
      Assert.AreEqual(10, mazeGenerator.Nodes[1].Count);
    }

    [TestMethod]
    public void DisposeMaze()
    {
      var mazeGenerator = new MazeGenerator(10, 10);

      mazeGenerator.Generate();

      mazeGenerator.Dispose();

      Assert.IsNull(mazeGenerator.Nodes);
    }

    [TestMethod]
    public void Game_InitalPosition()
    {
      var mazeGenerator = new MazeGenerator(10, 10);

      mazeGenerator.Generate();

      var mazeGameController = new MazeGameController(mazeGenerator.Nodes);      

      Assert.AreEqual(5, mazeGameController.State.PlayerPos.Item1);
      Assert.AreEqual(5, mazeGameController.State.PlayerPos.Item2);
    }

    [TestMethod]
    public void Game_Up()
    {
      var mazeGenerator = new MazeGenerator(10, 10);

      mazeGenerator.Generate();

      var mazeGameController = new MazeGameController(mazeGenerator.Nodes);

      bool moved = mazeGameController.TryUp();

      if(moved)
      {
        // At least one of the player coordinates has moved.
        Assert.AreEqual(5, mazeGameController.State.PlayerPos.Item1);
        Assert.AreEqual(4, mazeGameController.State.PlayerPos.Item2);
      }
      else
      {
        Assert.AreEqual(5, mazeGameController.State.PlayerPos.Item1);
        Assert.AreEqual(5, mazeGameController.State.PlayerPos.Item2);
      }
    }

    [TestMethod]
    public void Game_Down()
    {
      var mazeGenerator = new MazeGenerator(10, 10);

      mazeGenerator.Generate();

      var mazeGameController = new MazeGameController(mazeGenerator.Nodes);

      bool moved = mazeGameController.TryDown();

      if (moved)
      {
        // At least one of the player coordinates has moved.
        Assert.AreEqual(5, mazeGameController.State.PlayerPos.Item1);
        Assert.AreEqual(6, mazeGameController.State.PlayerPos.Item2);
      }
      else
      {
        Assert.AreEqual(5, mazeGameController.State.PlayerPos.Item1);
        Assert.AreEqual(5, mazeGameController.State.PlayerPos.Item2);
      }
    }

    [TestMethod]
    public void Game_Left()
    {
      var mazeGenerator = new MazeGenerator(10, 10);

      mazeGenerator.Generate();

      var mazeGameController = new MazeGameController(mazeGenerator.Nodes);

      bool moved = mazeGameController.TryLeft();

      if (moved)
      {
        // At least one of the player coordinates has moved.
        Assert.AreEqual(4, mazeGameController.State.PlayerPos.Item1);
        Assert.AreEqual(5, mazeGameController.State.PlayerPos.Item2);
      }
      else
      {
        Assert.AreEqual(5, mazeGameController.State.PlayerPos.Item1);
        Assert.AreEqual(5, mazeGameController.State.PlayerPos.Item2);
      }
    }

    [TestMethod]
    public void Game_Right()
    {
      var mazeGenerator = new MazeGenerator(10, 10);

      mazeGenerator.Generate();

      var mazeGameController = new MazeGameController(mazeGenerator.Nodes);

      bool moved = mazeGameController.TryLeft();

      if (moved)
      {
        // At least one of the player coordinates has moved.
        Assert.AreEqual(4, mazeGameController.State.PlayerPos.Item1);
        Assert.AreEqual(5, mazeGameController.State.PlayerPos.Item2);
      }
      else
      {
        Assert.AreEqual(5, mazeGameController.State.PlayerPos.Item1);
        Assert.AreEqual(5, mazeGameController.State.PlayerPos.Item2);
      }
    }

    [TestMethod]
    public void Game_State()
    {
      var mazeGenerator = new MazeGenerator(10, 10);

      mazeGenerator.Generate();

      var mazeGameController = new MazeGameController(mazeGenerator.Nodes);

      var settings = new JsonSerializerSettings()
      {
        ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
        PreserveReferencesHandling = PreserveReferencesHandling.Objects
      };

      var state = mazeGameController.SerializeState();

      mazeGameController.DeserializeState(state);

      Assert.AreEqual(10, mazeGenerator.Nodes.Count);
      Assert.AreEqual(10, mazeGenerator.Nodes[1].Count);
    }

    [TestMethod]
    public void Game_Win()
    {
      // Note: You can look at MazeState/maze.bmp to see what the maze to solve looks like.

      var state = System.IO.File.ReadAllText(@"MazeState/state.txt");

      var mazeGameController = new MazeGameController(state);

      var winX = 7;
      var winY = 1;

      Assert.IsTrue(mazeGameController.TryUp());
      Assert.IsTrue(mazeGameController.TryLeft());
      Assert.IsTrue(mazeGameController.TryDown());
      Assert.IsTrue(mazeGameController.TryDown());
      Assert.IsTrue(mazeGameController.TryDown());
      Assert.IsTrue(mazeGameController.TryRight());
      Assert.IsTrue(mazeGameController.TryUp());
      Assert.IsTrue(mazeGameController.TryRight());
      Assert.IsTrue(mazeGameController.TryUp());
      Assert.IsTrue(mazeGameController.TryRight());
      Assert.IsTrue(mazeGameController.TryUp());
      Assert.IsTrue(mazeGameController.TryUp());
      Assert.IsTrue(mazeGameController.TryUp());
      Assert.IsTrue(mazeGameController.TryRight());
      Assert.IsTrue(mazeGameController.TryUp());
      Assert.IsTrue(mazeGameController.TryLeft());

      Assert.AreEqual(winX, mazeGameController.State.PlayerPos.Item1);
      Assert.AreEqual(winY, mazeGameController.State.PlayerPos.Item2);

      // Check we can only move back

      Assert.IsFalse(mazeGameController.TryUp());
      Assert.IsFalse(mazeGameController.TryLeft());
      Assert.IsFalse(mazeGameController.TryDown());
      Assert.IsTrue(mazeGameController.TryRight());
    }

    [TestMethod]
    public void Game_AutoSolve()
    {
      // Note: You can look at MazeState/maze.bmp to see what the maze to solve looks like.

      var state = System.IO.File.ReadAllText(@"MazeState/state.txt");

      var mazeGameController = new MazeGameController(state);

      var winX = 7;
      var winY = 1;

      mazeGameController.Solve();

      Assert.AreEqual(winX, mazeGameController.State.PlayerPos.Item1);
      Assert.AreEqual(winY, mazeGameController.State.PlayerPos.Item2);
    }

    [TestMethod]
    public void Game_AutoSolve2()
    {
      // Note: You can look at MazeState/maze.bmp to see what the maze to solve looks like.

      var state = System.IO.File.ReadAllText(@"MazeState/state2.txt");

      var mazeGameController = new MazeGameController(state);

      var winX = 6;
      var winY = 6;

      mazeGameController.Solve();

      Assert.AreEqual(winX, mazeGameController.State.PlayerPos.Item1);
      Assert.AreEqual(winY, mazeGameController.State.PlayerPos.Item2);
    }

    [TestMethod]
    public void Game_AutoSolve3()
    {
      // Note: You can look at MazeState/maze.bmp to see what the maze to solve looks like.

      var state = System.IO.File.ReadAllText(@"MazeState/state3.txt");

      var mazeGameController = new MazeGameController(state);

      var winX = 1;
      var winY = 1;

      mazeGameController.Solve();

      Assert.AreEqual(winX, mazeGameController.State.PlayerPos.Item1);
      Assert.AreEqual(winY, mazeGameController.State.PlayerPos.Item2);
    }

    [TestMethod]
    public void Game_Dispose()
    {
      var mazeGenerator = new MazeGenerator(10, 10);

      mazeGenerator.Generate();

      var mazeGameController = new MazeGameController(mazeGenerator.Nodes);

      mazeGameController.Dispose();

      Assert.IsNull(mazeGameController.State);
    }
  }
}
