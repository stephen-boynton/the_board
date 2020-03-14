using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConeAbilityRange : AbilityRange
{
  public override bool directionOriented { get { return true; } }

  public override List<Cell> GetTilesInRange(GridManager grid)
  {
    PositionId pos = piece.currentCell.positionId;
    List<Cell> retValue = new List<Cell>();
    int dir = (piece.dir == Directions.North || piece.dir == Directions.East) ? 1 : -1;
    int lateral = 1;

    if (piece.dir == Directions.North || piece.dir == Directions.South)
    {
      for (int y = 1; y <= horizontal; ++y)
      {
        int min = -(lateral / 2);
        int max = (lateral / 2);
        for (int x = min; x <= max; ++x)
        {
          PositionId next = new PositionId(pos.row + x, pos.column + (y * dir));
          Cell cell = grid.GetCell(next);
          if (ValidTile(cell))
            retValue.Add(cell);
        }
        lateral += 2;
      }
    }
    else
    {
      for (int x = 1; x <= horizontal; ++x)
      {
        int min = -(lateral / 2);
        int max = (lateral / 2);
        for (int y = min; y <= max; ++y)
        {
          PositionId next = new PositionId(pos.row + (x * dir), pos.column + y);
          Cell cell = grid.GetCell(next);
          if (ValidTile(cell))
            retValue.Add(cell);
        }
        lateral += 2;
      }
    }

    return retValue;
  }

  bool ValidTile(Cell t)
  {
    return t != null && Mathf.Abs(t.height - piece.currentCell.height) <= vertical;
  }
}