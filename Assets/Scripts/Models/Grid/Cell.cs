using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
  [SerializeField] public Material defaultMaterial;
  [SerializeField] public Material selectMovementMaterial;
  [SerializeField] public Material selectAttackMaterial;
  [SerializeField] public Material selectConfirmMaterial;
  [SerializeField] public Material damaged;
  public static float STEP_HEIGHT = 0.2f;
  public Vector2 center { get; set; }
  public Vector2 lowerBounds { get; set; }
  public Vector2 upperBounds { get; set; }
  public int height { get; set; }
  public PositionId positionId { get; set; }
  public GameObject occupant { get; set; }
  public float heightOffset { get; set; }

  [HideInInspector] public Cell prev;
  [HideInInspector] public int distance;

  private void Awake()
  {
    heightOffset = transform.localScale.y;
  }

  public bool IsWithinBounds(Vector2 pos)
  {
    return MyUtility.Vect2GreaterThanEqualTo(pos, lowerBounds) && MyUtility.Vect2LessThanEqualTo(pos, upperBounds);
  }

  public void ChangeMoveSelectable()
  {
    transform.GetComponent<Renderer>().material = selectMovementMaterial;
  }

  public void ChangeAttackSelectable()
  {
    transform.GetComponent<Renderer>().material = selectAttackMaterial;
  }

  public void ChangeConfirmSelectable()
  {
    transform.GetComponent<Renderer>().material = selectConfirmMaterial;
  }

  public void ChangeDefault()
  {
    transform.GetComponent<Renderer>().material = defaultMaterial;
  }

}