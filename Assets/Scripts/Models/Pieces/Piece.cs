using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour
{
    public PositionId location { get; set; }
    public Cell currentCell;
    public Directions dir = Directions.North;

	public void Place(Cell target)
	{
		// Make sure old currentCell location is not still pointing to this unit
		if (currentCell != null && currentCell.occupant == gameObject)
			currentCell.occupant = null;

		// Link unit and currentCell references
		currentCell = target;

		if (target != null)
			target.occupant = gameObject;
	}

	public void Match()
	{
		transform.localPosition = currentCell.center;
		transform.localEulerAngles = dir.ToEuler();
	}
}