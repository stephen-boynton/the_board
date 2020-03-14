using UnityEngine;
using System.Collections;

public class FullTypeHitRate : HitRate
{
  public override bool IsAngleBased { get { return false; } }

  public override int Calculate(Cell target)
  {
    Piece defender = target.occupant.GetComponent<Piece>();
    if (AutomaticMiss(defender))
      return Final(100);

    return Final(0);
  }
}