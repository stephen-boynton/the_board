using UnityEngine;
using System.Collections;

public class KOdAbilityEffectTarget : AbilityEffectTarget
{
  public override bool IsTarget(Cell cell)
  {
    if (cell == null || cell.occupant == null)
      return false;

    Stats s = cell.occupant.GetComponent<Stats>();
    return s != null && s[StatTypes.HP] <= 0;
  }
}