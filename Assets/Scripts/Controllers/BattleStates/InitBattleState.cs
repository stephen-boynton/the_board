using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InitBattleState : BattleState
{
	public override void Enter()
	{
		base.Enter();
		StartCoroutine(Init());
	}

	IEnumerator Init()
	{
		currentCell = grid.GetCellByRowAndColumn((int)selector.startingPosition.x, (int)selector.startingPosition.y);
		grid.PlaceInGridNoOccupy(selector.startingPosition, selector.visualOffset, selector);
		yield return null;
	}

	protected override void OnMouseMoveEvent(object sender, InfoEventArgs<Vector3> e)
	{
		Cell hoveredCell = grid.GetCellByWorldLocation(e.info);
        if(hoveredCell != currentCell)
        {
			currentCell = hoveredCell;
			selector.transform.position = new Vector3(currentCell.center.x, currentCell.cellHeightOffset + selector.visualOffset, currentCell.center.y);
        }
	}
}