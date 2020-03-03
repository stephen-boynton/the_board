using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBattleState : BattleState {
	public override void Enter () {
		base.Enter ();
		StartCoroutine (Init ());
	}

	IEnumerator Init () {
		CellSelector cellSelector = selector.GetComponent<CellSelector> ();
		Piece activePiece = teamOne[0].GetComponent<Piece> ();

		currentCell = grid.GetCellByRowAndColumn ((int) cellSelector.startingPosition.x, (int) cellSelector.startingPosition.y);
		grid.PlaceInGridNoOccupy (cellSelector.startingPosition, cellSelector.visualOffset, selector);
		grid.PlaceInGrid (new Vector2 (0, 0), activePiece.offset / 2, teamOne[0]);
		activePiece.Place(grid.GetCellByPositionId(new PositionId(0, 0)));
		yield return null;
	}

	protected override void OnMouseMoveEvent (object sender, InfoEventArgs<Vector3> e) {
		Cell hoveredCell = grid.GetCellByWorldLocation (e.info);
		if (hoveredCell != currentCell) {
			currentCell = hoveredCell;
			selector.transform.position = new Vector3 (
				currentCell.center.x,
				currentCell.cellHeightOffset + selector.GetComponent<CellSelector> ().visualOffset,
				currentCell.center.y
			);
		}
	}

	protected override void OnFire (object sender, InfoEventArgs<int> e) {
		if (currentCell.occupant == teamOne[0]) {
			Debug.Log ("Yippeeeee!");
			owner.ChangeState<MoveTargetState> ();
		}
	}
}