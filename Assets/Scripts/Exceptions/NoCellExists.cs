using System;

public class NoCellExists : Exception
{
  public NoCellExists()
  {
  }

  public NoCellExists(string message)
      : base(message)
  {
  }

  public NoCellExists(string message, Exception inner)
      : base(message, inner)
  {
  }
}