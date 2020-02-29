using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {
    public Vector2 coordinates { get; set; }
    public int height { get; set; }
    public PositionId positionId { get; set; }
    public bool isOccupied;
    public GameObject placeholderTile;
    public GameObject prefab;

    public void ScalePrefabToSquare () {
        placeholderTile = this.transform.GetChild (0).gameObject;
        Vector3 size = placeholderTile.GetComponent<Renderer> ().bounds.size;
        // prefab.transform.localScale = size;     
    }

}