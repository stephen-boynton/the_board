using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
  private const float CELL_SIZE = 1.0f;
  private float CELL_OFFSET;
  private float HEIGHT_SIZE = 0.3f;
  [SerializeField] GameObject CellPrefab;
  [SerializeField] int gridSize = 8;

  private int START_ROW = 0;
  private int END_ROW;

  private List<Cell> Cells = new List<Cell>();

  // System

  private void Awake()
  {
    Init();
    SpawnAllTiles();
  }

  private void Update()
  {
    DrawChessboard();
  }

  // Private Methods

  private void Init()
  {
    CELL_OFFSET = CELL_SIZE / 2.0f;
    END_ROW = gridSize - 1;
  }

  private void DrawChessboard()
  {
    Vector3 widthLine = Vector3.right * gridSize;
    Vector3 heightLine = Vector3.forward * gridSize;

    for (int i = 0; i <= gridSize; i++)
    {
      Vector3 start = Vector3.forward * i;
      Debug.DrawLine(start, start + widthLine);
      for (int j = 0; j <= gridSize; j++)
      {
        start = Vector3.right * j;
        Debug.DrawLine(start, start + heightLine);
      }
    }
  }

  private void SpawnAllTiles()
  {
    for (int i = 0; i < gridSize; i++)
    {
      for (int j = 0; j < gridSize; j++)
      {
        Vector3 center = GetCellCenter(i, j);

        GameObject cell = Instantiate(CellPrefab, center, Quaternion.identity);
        Cell cellComp = cell.AddComponent<Cell>();

        cellComp.center = new Vector2(center.x, center.z);
        cellComp.lowerBounds = new Vector2(i, j);
        cellComp.upperBounds = new Vector2(i + CELL_SIZE, j + CELL_SIZE);
        cellComp.height = 0;
        cellComp.positionId = new PositionId(i, j);

        Cells.Add(cellComp);
        cell.transform.SetParent(transform);
      }
    }
  }

  // Public Methods

  public Vector3 GetCellCenter(int x, int y)
  {
    Vector3 origin = Vector3.zero;
    origin.x += (CELL_SIZE * x) + CELL_OFFSET;
    origin.z += (CELL_SIZE * y) + CELL_OFFSET;
    return origin;
  }

  public Cell GetCellByWorldLocation(Vector3 loc)
  {
    foreach (Cell c in Cells)
    {
      if (c.IsWithinBounds(new Vector2(loc.x, loc.z)))
        return c;
    }
    return null;
  }

  public Cell GetCellByRowAndColumn(int row, int column)
  {
    foreach (Cell c in Cells)
    {
      if (c.positionId == new PositionId(row, column))
        return c;
    }
    return null;
  }
}