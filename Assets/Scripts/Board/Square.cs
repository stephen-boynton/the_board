using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {
    private Vector2 coordinates { get; set; }
    private int height { get; set; }
    private PositionId positionId { get; set; }
    public bool isOccupied;
    public GameObject placeholderTile;
    public GameObject prefab;

    private void ScalePrefabToSquare () {
        Vector3 size = placeholderTile.GetComponent<Renderer> ().bounds.size;
        prefab.transform.localScale = size;
    }

}