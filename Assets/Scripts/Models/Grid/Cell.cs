using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
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
  public float cellHeightOffset { get; set; }
  public List<GameObject> prefabInstances = new List<GameObject> ();

  private GameObject activeCellBlock;

  [HideInInspector] public Cell prev;
  [HideInInspector] public int distance;

  private void Start () {
    activeCellBlock = prefabInstances.Count > 0 ? prefabInstances[prefabInstances.Count - 1] : gameObject;
  }

  public bool IsWithinBounds (Vector2 pos) {
    return MyUtility.Vect2GreaterThanEqualTo (pos, lowerBounds) && MyUtility.Vect2LessThanEqualTo (pos, upperBounds);
  }

  public void ChangeSelectable () {
    activeCellBlock.transform.GetComponent<Renderer> ().material = selectMovementMaterial;
  }

  public void ChangeDefault () {
    activeCellBlock.transform.GetComponent<Renderer> ().material = defaultMaterial;
  }

}