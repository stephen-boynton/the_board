using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour {
	public PositionId location { get; set; }
	public Cell currentCell;
	public Directions dir = Directions.North;
	public float offset;
	public virtual int CTR { get; protected set; }
	public virtual int SPEED { get; protected set; }

	[SerializeField] public Vector2 startingPosition;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake () {
		offset = transform.GetChild (0).GetComponent<Renderer> ().bounds.size.y / 2;
	}

	public void Place (Cell target) {
		// Make sure old currentCell location is not still pointing to this unit
		if (currentCell != null && currentCell.occupant == gameObject)
			currentCell.occupant = null;

		// Link unit and currentCell references
		currentCell = target;
		location = target.positionId;

		if (target != null) {
			target.occupant = gameObject;
		}
	}

	public void Match () {
		transform.localPosition = currentCell.center;
		transform.localEulerAngles = dir.ToEuler ();
	}
}