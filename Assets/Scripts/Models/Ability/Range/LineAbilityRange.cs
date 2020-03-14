using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineAbilityRange : AbilityRange
{
  public override bool directionOriented { get { return true; } }

  public override List<Cell> GetTilesInRange(GridManager grid)
  {
    PositionId startPos = piece.currentCell.positionId;
    PositionId endPos;
    List<Cell> retValue = new List<Cell>();

    switch (piece.dir)
    {
      case Directions.North:
        endPos = new PositionId(startPos.row, grid.max.column);
        break;
      case Directions.East:
        endPos = new PositionId(grid.max.row, startPos.column);
        break;
      case Directions.South:
        endPos = new PositionId(startPos.row, grid.min.column);
        break;
      default: // West
        endPos = new PositionId(grid.min.row, startPos.column);
        break;
    }

    int dist = 0;
    while (startPos != endPos)
    {
      if (startPos.row < endPos.row) startPos.row++;
      else if (startPos.row > endPos.row) startPos.row--;

      if (startPos.column < endPos.column) startPos.column++;
      else if (startPos.column > endPos.column) startPos.column--;

      Cell t = grid.GetCell(startPos);
      if (t != null && Mathf.Abs(t.height - piece.currentCell.height) <= vertical)
        retValue.Add(t);

      dist++;
      if (dist >= horizontal)
        break;
    }

    return retValue;
  }
}