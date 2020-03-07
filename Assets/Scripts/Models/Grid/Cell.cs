using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
  [SerializeField] public Material defaultMaterial;
  [SerializeField] public Material selectMovementMaterial;
  [SerializeField] public Material select_attack;
  [SerializeField] public Material damaged;
  public Vector2 center { get; set; }
  public Vector2 lowerBounds { get; set; }
  public Vector2 upperBounds { get; set; }
  public int height { get; set; }
  public PositionId positionId { get; set; }
  public GameObject occupant { get; set; }
  public float cellHeightOffset = 0.0f;
  [HideInInspector] public Cell prev;
  [HideInInspector] public int distance;

  private void Awake()
  {
    cellHeightOffset = transform.GetComponent<Renderer>().bounds.size.y / 2;
  }

  public bool IsWithinBounds(Vector2 pos)
  {
    return MyUtility.Vect2GreaterThanEqualTo(pos, lowerBounds) && MyUtility.Vect2LessThanEqualTo(pos, upperBounds);
  }

  public void ChangeSelectable()
  {
    transform.GetComponent<Renderer>().material = selectMovementMaterial;
  }

  public void ChangeDefault()
  {
    transform.GetComponent<Renderer>().material = defaultMaterial;
  }

}