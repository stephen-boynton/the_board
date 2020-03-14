using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpecifyAbilityArea : AbilityArea
{
  public int horizontal;
  public int vertical;
  Cell cell;

  public override List<Cell> GetTilesInArea(GridManager grid, PositionId pos)
  {
    cell = grid.GetCell(pos);
    return grid.Search(cell, ExpandSearch);
  }

  bool ExpandSearch(Cell from, Cell to)
  {
    return (from.distance + 1) <= horizontal && Mathf.Abs(to.height - cell.height) <= vertical;
  }
}