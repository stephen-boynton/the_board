﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Movement : MonoBehaviour
{
    public int range = 3;
    protected Piece piece;


    protected virtual void Awake()
    {
        piece = GetComponent<Piece>();
    }



    public virtual List<Cell> GetCellsInRange(GridManager grid)
    {
        List<Cell> retValue = grid.Search(piece.currentCell, ExpandSearch);
        Filter(retValue);
        return retValue;
    }

    public abstract IEnumerator Traverse(Cell cell);

    #region Protected
    protected virtual bool ExpandSearch(Cell from, Cell to)
    {
        return (from.distance + 1) <= range;
    }

    protected virtual void Filter(List<Cell> cells)
    {
        for (int i = cells.Count - 1; i >= 0; --i)
            if (cells[i].occupant != null)
                cells.RemoveAt(i);
    }

    protected virtual IEnumerator Turn(Directions dir)
    {
        TransformLocalEulerTweener t = (TransformLocalEulerTweener)transform.RotateToLocal(dir.ToEuler(), 0.25f, EasingEquations.EaseInOutQuad);

        // When rotating between North and West, we must make an exception so it looks like the unit
        // rotates the most efficient way (since 0 and 360 are treated the same)
        if (Mathf.Approximately(t.startValue.y, 0f) && Mathf.Approximately(t.endValue.y, 270f))
            t.startValue = new Vector3(t.startValue.x, 360f, t.startValue.z);
        else if (Mathf.Approximately(t.startValue.y, 270) && Mathf.Approximately(t.endValue.y, 0))
            t.endValue = new Vector3(t.startValue.x, 360f, t.startValue.z);

        piece.dir = dir;

        while (t != null)
            yield return null;
    }
    #endregion
}