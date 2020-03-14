using UnityEngine;
using System.Collections;

public class MatchException : BaseException
{
  public readonly Piece attacker;
  public readonly Piece target;

  public MatchException(Piece attacker, Piece target) : base(false)
  {
    this.attacker = attacker;
    this.target = target;
  }
}
