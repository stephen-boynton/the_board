using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelfAbilityRange : AbilityRange
{
  public override bool positionOriented { get { return false; } }

  public override List<Cell> GetTilesInRange(GridManager grid)
  {
    List<Cell> retValue = new List<Cell>(1);
    retValue.Add(piece.currentCell);
    return retValue;
  }
}