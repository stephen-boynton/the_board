using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyUtility
{
  public static void RotateGameObject(MonoBehaviour go, Vector3 degrees)
  {
    Debug.Log(go.transform.eulerAngles.y);
    go.transform.eulerAngles = new Vector3(
        go.transform.eulerAngles.x + degrees.x,
        go.transform.eulerAngles.y + degrees.y,
        go.transform.eulerAngles.z + degrees.z
    );
    Debug.Log(go.transform.eulerAngles.y);
  }

  public static bool Vect2GreaterThanEqualTo(Vector2 a, Vector2 b)
  {
    bool isX = a.x >= b.x;
    bool isY = a.y >= b.y;
    return isX && isY;
  }

  public static bool Vect2LessThanEqualTo(Vector2 a, Vector2 b)
  {
    bool isX = a.x <= b.x;
    bool isY = a.y <= b.y;
    return isX && isY;
  }
}