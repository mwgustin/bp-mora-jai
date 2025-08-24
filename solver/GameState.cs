using System.Diagnostics.CodeAnalysis;
using System.Text;

public record GameState : IEquatable<GameState>
{
  public TileColor[,] Board;
  public readonly TileColor Goal;

  public GameState(TileColor[,] board, TileColor Goal)
  {
    if (board.GetLength(0) != 3 || board.GetLength(1) != 3)
    {
      throw new ArgumentException("Board must be 3x3");
    }

    Board = board;
    this.Goal = Goal;
  }

  // if corners are goal color then return true
  public bool IsSolved()
  {
    return Board[0, 0] == Goal &&
           Board[0, 2] == Goal &&
           Board[2, 0] == Goal &&
           Board[2, 2] == Goal;
  }
  public bool Equals(GameState? x, GameState? y)
  {
    if (x == null && y == null) return true;
    if (x == null || y == null) return false;

    if (x.Goal != y.Goal) return false;

    for (int r = 0; r < 3; r++)
    {
      for (int c = 0; c < 3; c++)
      {
        if (x.Board[r, c] != y.Board[r, c]) return false;
      }
    }

    return true;
  }

  public override int GetHashCode()
  {
    StringBuilder sb = new StringBuilder();
    sb.Append((int)Goal);
    for (int r = 0; r < 3; r++)
    {
      for (int c = 0; c < 3; c++)
      {
        sb.Append((int)Board[r, c]);
      }
    }

    return sb.ToString().GetHashCode();
  }

  public override string ToString()
  {
    StringBuilder sb = new StringBuilder();
    for (int r = 0; r < 3; r++)
    {
      for (int c = 0; c < 3; c++)
      {
        sb.Append(Board[r, c].ToString().PadRight(7));
        if (c < 2) sb.Append("| ");
      }
      sb.AppendLine();
      if (r < 2) sb.AppendLine(new string('-', 23));
    }
    return sb.ToString();
  }

  // 0,0 | 0,1 | 0,2
  // -----------------
  // 1,0 | 1,1 | 1,2
  // -----------------
  // 2,0 | 2,1 | 2,2
}

