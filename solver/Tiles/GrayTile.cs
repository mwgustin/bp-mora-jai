// See https://aka.ms/new-console-template for more information
public class GrayTile : ITile
{
  public GameState Press(GameState state, int row, int col)
  {
    // Gray tile does nothing
    return state;
  }
}
