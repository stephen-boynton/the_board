using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyUtility
{
  public static void RotateGameObject(MonoBehaviour go, Vector3 degrees)
  {
    go.transform.eulerAngles = new Vector3(
      go.transform.eulerAngles.x + degrees.x,
      go.transform.eulerAngles.y + degrees.y,
      go.transform.eulerAngles.z + degrees.z
    );
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

  public static int GetRandomWeightedIndex(int[,] spec)
  {
    int totalChance = 0;
    for (int i = 0; i < spec.Length / 2; i++)
    {
      totalChance += spec[i, 1];
    }

    int rando = Random.Range(0, totalChance);

    for (int i = 0; i < spec.Length / 2; i++)
    {
      if ((rando -= spec[i, 1]) < 0)
        return spec[i, 0];
    }
    return -1;
  }

  public static int[,] BuildBoard()
  {
    return new int[,] {
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,3,4,4,4,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,2,4,5,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
      {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
    };
  }
}