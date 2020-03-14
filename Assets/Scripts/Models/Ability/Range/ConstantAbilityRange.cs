using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConstantAbilityRange : AbilityRange
{
  public override List<Cell> GetTilesInRange(GridManager grid)
  {
    return grid.Search(piece.currentCell, ExpandSearch);
  }

  bool ExpandSearch(Cell from, Cell to)
  {
    return (from.distance + 1) <= horizontal && Mathf.Abs(to.height - piece.currentCell.height) <= vertical;
  }
}