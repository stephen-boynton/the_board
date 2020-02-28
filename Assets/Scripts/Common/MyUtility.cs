using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyUtility {
    public static void RotateGameObject (MonoBehaviour go, Vector3 degrees) {
        go.transform.eulerAngles = new Vector3 (
            go.transform.eulerAngles.x + degrees.x,
            go.transform.eulerAngles.y + degrees.y,
            go.transform.eulerAngles.z + degrees.z
        );
    }
}