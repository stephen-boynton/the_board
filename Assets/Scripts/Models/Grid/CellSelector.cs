using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSelector : MonoBehaviour
{
  private Vector2 _location;
  public Vector2 Location
  {
    get { return _location; }
    set
    {
      OnLocationChange(value);
      this._location = value;
    }
  }

    [SerializeField] public Vector2 startingPosition = Vector2.zero;
    [SerializeField] public float visualOffset = 0.05f;

    private void Awake()
  {
    Location = startingPosition;
  }

  private void OnLocationChange(Vector2 loc)
  {
    transform.position = new Vector3(loc.x, 0, loc.y);
  }

}