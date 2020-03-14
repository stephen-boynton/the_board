using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FullAbilityArea : AbilityArea
{
  public override List<Cell> GetTilesInArea(GridManager grid, PositionId pos)
  {
    AbilityRange ar = GetComponent<AbilityRange>();
    return ar.GetTilesInRange(grid);
  }
}