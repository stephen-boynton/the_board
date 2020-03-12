using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
  private const float CELL_SIZE = 1.0f;
  private float CELL_OFFSET;
  [SerializeField] GameObject CellPrefab;
  [SerializeField] GameObject[] CellSizes;
  [SerializeField] int gridSize = 8;
  private int END_ROW;

  PositionId[] dirs = new PositionId[4] {
    new PositionId (0, 1),
    new PositionId (0, -1),
    new PositionId (1, 0),
    new PositionId (-1, 0)
  };

  public Dictionary<PositionId, Cell> Cells = new Dictionary<PositionId, Cell>();
  // SYSTEM FXS ======================================================== //

  private void Awake()
  {
    Init();
    SpawnAllCells();
  }

  private void Update()
  {
    DrawChessboard();
  }

  // INIT FXS ======================================================== //

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

  private void SpawnAllCells()
  {
    for (int i = 0; i < gridSize; i++)
    {
      for (int j = 0; j < gridSize; j++)
      {
        SpawnCell(i, j);
      }
    }
  }

  private void SpawnCell(int i, int j)
  {
    Vector3 center = GetCellCenter(i, j);

    int height = 0;

    GameObject cell = Instantiate(CellSizes[height]);
    Cell cellComp = cell.AddComponent<Cell>();

    cell.transform.position = new Vector3(
      center.x,
      cellComp.heightOffset / 2,
      center.z
    );

    cellComp.height = height;
    cellComp.center = new Vector2(center.x, center.z);
    cellComp.lowerBounds = new Vector2(i, j);
    cellComp.upperBounds = new Vector2(i + CELL_SIZE, j + CELL_SIZE);
    cellComp.positionId = new PositionId(i, j);
    cellComp.defaultMaterial = CellPrefab.GetComponent<Cell>().defaultMaterial;
    cellComp.selectMovementMaterial = CellPrefab.GetComponent<Cell>().selectMovementMaterial;

    // Add references where appropriate
    Cells.Add(cellComp.positionId, cellComp);
    cell.transform.SetParent(transform);
  }

  // PUBLIC FXS ======================================================== //

  public void PlaceInGridNoOccupy(Vector3 loc, float heightOffset, GameObject item)
  {
    Cell cell = GetCellByWorldLocation(loc);
    item.transform.position = new Vector3(cell.center.x, cell.heightOffset + heightOffset, cell.center.y);
  }

  public void PlaceInGrid(Vector2 loc, float heightOffSet, GameObject item)
  {
    Cell cell = GetCellByRowAndColumn((int)loc.x, (int)loc.y);
    cell.occupant = item;
    item.transform.position = new Vector3(cell.center.x, cell.heightOffset + heightOffSet, cell.center.y);
  }

  public List<Cell> Search(Cell start, Func<Cell, Cell, bool> addCell)
  {
    List<Cell> retValue = new List<Cell>();
    retValue.Add(start);

    ClearSearch();
    Queue<Cell> checkNext = new Queue<Cell>();
    Queue<Cell> checkNow = new Queue<Cell>();

    start.distance = 0;
    checkNow.Enqueue(start);

    while (checkNow.Count > 0)
    {
      Cell c = checkNow.Dequeue();
      for (int i = 0; i < 4; ++i)
      {
        Cell next = GetCell(c.positionId + dirs[i]);

        if (next == null || next.distance <= c.distance + 1)
        {
          continue;
        }

        if (addCell(c, next))
        {
          next.distance = c.distance + 1;
          next.prev = c;
          checkNext.Enqueue(next);
          retValue.Add(next);
        }
      }

      if (checkNow.Count == 0)
        SwapReference(ref checkNow, ref checkNext);
    }

    return retValue;
  }

  public Cell GetCell(PositionId p)
  {
    return Cells.ContainsKey(p) ? Cells[p] : null;
  }

  public Vector3 GetCellCenter(int x, int y)
  {
    Vector3 origin = Vector3.zero;
    origin.x += (CELL_SIZE * x) + CELL_OFFSET;
    origin.z += (CELL_SIZE * y) + CELL_OFFSET;
    return origin;
  }

  public Cell GetCellByWorldLocation(Vector3 loc)
  {
    foreach (Cell c in Cells.Values)
    {
      if (c.IsWithinBounds(new Vector2(loc.x, loc.z)))
        return c;
    }
    return null;
  }

  public Cell GetCellByPositionId(PositionId pos)
  {
    foreach (PositionId c in Cells.Keys)
    {
      if (c == pos)
        return Cells[c];
    }
    return null;
  }

  public Cell GetCellByRowAndColumn(int row, int column)
  {
    foreach (PositionId c in Cells.Keys)
    {
      if (c == new PositionId(row, column))
        return Cells[c];
    }
    return null;
  }

  void ClearSearch()
  {
    foreach (Cell c in Cells.Values)
    {
      c.prev = null;
      c.distance = int.MaxValue;
    }
  }

  void SwapReference(ref Queue<Cell> a, ref Queue<Cell> b)
  {
    Queue<Cell> temp = a;
    a = b;
    b = temp;
  }

  public void SelectCells(List<Cell> cells)
  {
    for (int i = cells.Count - 1; i >= 0; --i)
      cells[i].ChangeSelectable();
  }

  public void DeSelectCells(List<Cell> cells)
  {
    for (int i = cells.Count - 1; i >= 0; --i)
      cells[i].ChangeDefault();
  }
}