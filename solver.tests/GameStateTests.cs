namespace solver.tests;

public class GameStateTests
{
  [Test]
  public async Task IsSolved_WhenSolved_Should_ReturnTrue()
  {
    var board = new TileColor[3, 3]
    {
              { TileColor.Red, TileColor.Blue, TileColor.Red },
              { TileColor.Green, TileColor.Yellow, TileColor.Green },
              { TileColor.Red, TileColor.Blue, TileColor.Red }
    };
    var goal = TileColor.Red;
    var gameState = new GameState(board, goal);

    await Assert.That(gameState.IsSolved()).IsTrue();
  }

  [Test]
  public async Task IsSolved_WhenNotSolved_Should_ReturnFalse()
  {
    var board = new TileColor[3, 3]
    {
              { TileColor.Red, TileColor.Blue, TileColor.Green },
              { TileColor.Green, TileColor.Yellow, TileColor.Green },
              { TileColor.Red, TileColor.Blue, TileColor.Red }
    };
    var goal = TileColor.Red;
    var gameState = new GameState(board, goal);

    await Assert.That(gameState.IsSolved()).IsFalse();
  }

  [Test]
  public async Task Constructor_WhenBoardIsNot3x3_Should_ThrowArgumentException()
  {
    var board = new TileColor[2, 3]
    {
              { TileColor.Red, TileColor.Blue, TileColor.Red },
              { TileColor.Green, TileColor.Yellow, TileColor.Green }
    };
    var goal = TileColor.Red;

    await Assert.ThrowsAsync<ArgumentException>(() => Task.Run(() => new GameState(board, goal)));
  }
}
