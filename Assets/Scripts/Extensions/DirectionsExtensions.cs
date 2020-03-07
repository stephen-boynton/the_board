using UnityEngine;
using System.Collections;

public static class DirectionsExtensions
{
	public static Directions GetDirection(this Cell c1, Cell c2)
	{
		if (c1.positionId.column < c2.positionId.column)
			return Directions.North;
		if (c1.positionId.row < c2.positionId.row)
			return Directions.East;
		if (c1.positionId.column > c2.positionId.column)
			return Directions.South;
		return Directions.West;
	}

	public static Vector3 ToEuler(this Directions d)
	{
		return new Vector3(0, (int)d * 90, 0);
	}

	public static Directions GetDirection(this PositionId p)
	{
		if (p.column > 0)
			return Directions.North;
		if (p.row > 0)
			return Directions.East;
		if (p.column < 0)
			return Directions.South;
		return Directions.West;
	}

	public static PositionId GetNormal(this Directions dir)
	{
		switch (dir)
		{
			case Directions.North:
				return new PositionId(0, 1);
			case Directions.East:
				return new PositionId(1, 0);
			case Directions.South:
				return new PositionId(0, -1);
			default: // Directions.West:
				return new PositionId(-1, 0);
		}
	}
}