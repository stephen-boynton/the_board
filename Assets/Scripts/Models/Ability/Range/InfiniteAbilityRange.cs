using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InfiniteAbilityRange : AbilityRange
{
  public override bool positionOriented { get { return false; } }

  public override List<Cell> GetTilesInRange(GridManager grid)
  {
    return new List<Cell>(grid.Cells.Values);
  }
}