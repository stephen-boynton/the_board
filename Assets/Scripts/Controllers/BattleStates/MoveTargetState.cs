using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetState : BattleState {
	List<Cell> cells = new List<Cell> ();

	public override void Enter () {
		base.Enter ();
		Debug.Log ("Here we at mofos");

		Movement mover = teamOne[0].GetComponent<Movement> ();
		cells = mover.GetCellsInRange (grid);
		grid.SelectCells (cells);
	}
}