using System.Text;
// class used to represent the solution tree.

namespace MoraJai.Lib;

public class SolutionNode
{
  public GameState State;
  public SolutionNode? Parent;
  public int Depth => Parent == null ? 0 : Parent.Depth + 1;
  public (int, int) Move;

  public SolutionNode(GameState state, SolutionNode? parent, (int, int) move)
  {
    State = state;
    Move = move;
    Parent = parent;
  }

  public override string ToString()
  {
    var sb = new StringBuilder();
    if (Move != (-1, -1))
    {
      sb.AppendLine($"Move: Pressed tile at ({Move.Item1}, {Move.Item2})");
    }
    sb.AppendLine($"Depth: {Depth}");
    sb.AppendLine($"Board: \n{State}");
    sb.AppendLine();
    return sb.ToString();
  }

  public void PrintSolution(SolutionNode node)
  {
    if (node.Parent != null)
    {
      PrintSolution(node.Parent);
    }
    Console.WriteLine(node);
  }
}