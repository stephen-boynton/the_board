using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitAbilityArea : AbilityArea
{
  public override List<Cell> GetTilesInArea(GridManager grid, PositionId pos)
  {
    List<Cell> retValue = new List<Cell>();
    Cell cell = grid.GetCell(pos);
    if (cell != null)
      retValue.Add(cell);
    return retValue;
  }
}
