using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
  public Vector2 center { get; set; }
  public Vector2 lowerBounds { get; set; }
  public Vector2 upperBounds { get; set; }
  public int height { get; set; }
  public PositionId positionId { get; set; }
  public bool isOccupied;
  public GameObject placeholderTile;
  public GameObject prefab;

  public bool IsWithinBounds(Vector2 pos)
  {
    return MyUtility.Vect2GreaterThanEqualTo(pos, lowerBounds) && MyUtility.Vect2LessThanEqualTo(pos, upperBounds);
  }

}