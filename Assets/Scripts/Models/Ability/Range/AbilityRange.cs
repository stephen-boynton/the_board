using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbilityRange : MonoBehaviour
{
  public int horizontal = 1;
  public int vertical = int.MaxValue;
  public virtual bool positionOriented { get { return true; } }
  public virtual bool directionOriented { get { return false; } }
  protected Piece piece { get { return GetComponentInParent<Piece>(); } }

  public abstract List<Cell> GetTilesInRange(GridManager grid);
}