using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WalkMovement : Movement
{
	#region Protected
	protected override bool ExpandSearch(Cell from, Cell to)
	{

		// Skip if the tile is occupied by an enemy
		if (to.occupant != null)
			return false;

		return base.ExpandSearch(from, to);
	}

	public override IEnumerator Traverse(Cell tile)
	{
		piece.Place(tile);

		// Build a list of way points from the piece's 
		// starting tile to the destination tile
		List<Cell> targets = new List<Cell>();
		while (tile != null)
		{
			targets.Insert(0, tile);
			tile = tile.prev;
		}

		// Move to each way point in succession
		for (int i = 1; i < targets.Count; ++i)
		{
			Cell from = targets[i - 1];
			Cell to = targets[i];

			Directions dir = from.GetDirection(to);
			if (piece.dir != dir)
				yield return StartCoroutine(Turn(dir));

			if (from.height == to.height)
				yield return StartCoroutine(Walk(to));
		}

		yield return null;
	}
	#endregion

	#region Private
	IEnumerator Walk(Cell target)
	{
		Tweener tweener = transform.MoveTo(target.center, 0.5f, EasingEquations.Linear);
		while (tweener != null)
			yield return null;
	}
	#endregion
}