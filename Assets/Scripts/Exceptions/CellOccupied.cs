using System;

public class CellOccupied : Exception
{
  public CellOccupied()
  {
  }

  public CellOccupied(string message)
      : base(message)
  {
  }

  public CellOccupied(string message, Exception inner)
      : base(message, inner)
  {
  }
}