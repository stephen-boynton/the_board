using UnityEngine;
using System.Collections;

public class STypeHitRate : HitRate
{
  public override int Calculate(Cell target)
  {
    Piece defender = target.occupant.GetComponent<Piece>();
    if (AutomaticMiss(defender))
      return Final(100);

    if (AutomaticHit(defender))
      return Final(0);

    int res = GetResistance(defender);
    res = AdjustForStatusEffects(defender, res);
    // res = AdjustForRelativeFacing(defender, res);
    res = Mathf.Clamp(res, 0, 100);
    return Final(res);
  }

  int GetResistance(Piece target)
  {
    Stats s = target.GetComponentInParent<Stats>();
    return s[StatTypes.RES];
  }

  // int AdjustForRelativeFacing(Piece target, int rate)
  // {
  //   switch (attacker.GetFacing(target))
  //   {
  //     case Facings.Front:
  //       return rate;
  //     case Facings.Side:
  //       return rate - 10;
  //     default:
  //       return rate - 20;
  //   }
  // }
}