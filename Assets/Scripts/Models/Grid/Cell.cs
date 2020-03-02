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
    public bool isOccupied { get; private set; }
    public float cellHeightOffset = 0.0f;
    [SerializeField] public GameObject occupant;
    [HideInInspector] public Cell prev;
    [HideInInspector] public int distance;

    private void Awake()
    {
        cellHeightOffset = transform.GetChild(0).GetComponent<Renderer>().bounds.size.y / 2;
    }

    public bool IsWithinBounds(Vector2 pos)
    {
        return MyUtility.Vect2GreaterThanEqualTo(pos, lowerBounds) && MyUtility.Vect2LessThanEqualTo(pos, upperBounds);
    }

    public void Occupy(GameObject item)
    {
        isOccupied = true;
        occupant = item;
    }

    public void Vacate()
    {
        isOccupied = false;
        occupant = null;
    }

}