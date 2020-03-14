using UnityEngine;
using System.Collections;

public class EnemyAbilityEffectTarget : AbilityEffectTarget
{
  Alliance alliance;

  void Start()
  {
    alliance = GetComponentInParent<Alliance>();
  }

  public override bool IsTarget(Cell cell)
  {
    if (cell == null || cell.occupant == null)
      return false;

    Alliance other = cell.occupant.GetComponentInChildren<Alliance>();
    return alliance.IsMatch(other, Targets.Foe);
  }
}