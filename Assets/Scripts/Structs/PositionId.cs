using System.Collections;
using UnityEngine;

[System.Serializable]
public struct PositionId {
    #region Fields
    public int row;
    public int column;
    #endregion

    #region Constructors
    public PositionId (int row, int column) {
        this.row = row;
        this.column = column;
    }
    #endregion

    public static implicit operator Vector2 (PositionId p) {
        return new Vector2 (p.row, p.column);
    }

    #region Operator Overloads
    public static PositionId operator + (PositionId a, PositionId b) {
        return new PositionId (a.row + b.row, a.column + b.column);
    }

    public static PositionId operator - (PositionId p1, PositionId p2) {
        return new PositionId (p1.row - p2.row, p1.column - p2.column);
    }

    public static bool operator == (PositionId a, PositionId b) {
        return a.row == b.row && a.column == b.column;
    }

    public static bool operator != (PositionId a, PositionId b) {
        return !(a == b);
    }
    #endregion

    #region Object Overloads
    public override bool Equals (object obj) {
        if (obj is PositionId) {
            PositionId p = (PositionId) obj;
            return row == p.row && column == p.column;
        }
        return false;
    }

    public bool Equals (PositionId p) {
        return row == p.row && column == p.column;
    }

    public override int GetHashCode () {
        return row ^ column;
    }

    public override string ToString () {
        return string.Format ("({0},{1})", row, column);
    }
    #endregion
}