using UnityEngine;
using System.Collections;

public class ATypeHitRate : HitRate
{
  public override int Calculate(Cell target)
  {
    Piece defender = target.occupant.GetComponent<Piece>();
    if (AutomaticHit(defender))
      return Final(0);

    if (AutomaticMiss(defender))
      return Final(100);

    int evade = GetEvade(defender);
    // evade = AdjustForRelativeFacing(defender, evade);
    evade = AdjustForStatusEffects(defender, evade);
    evade = Mathf.Clamp(evade, 5, 95);
    return Final(evade);
  }

  int GetEvade(Piece target)
  {
    Stats s = target.GetComponentInParent<Stats>();
    return Mathf.Clamp(s[StatTypes.EVD], 0, 100);
  }

  // int AdjustForRelativeFacing(Piece target, int rate)
  // {
  //   switch (attacker.GetFacing(target))
  //   {
  //     case Facings.Front:
  //       return rate;
  //     case Facings.Side:
  //       return rate / 2;
  //     default:
  //       return rate / 4;
  //   }
  // }
}