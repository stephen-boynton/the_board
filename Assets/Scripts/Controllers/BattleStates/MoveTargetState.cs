using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetState : BattleState
{
  List<Cell> cells = new List<Cell>();

  public override void Enter()
  {
    base.Enter();
    Movement mover = turn.actor.GetComponent<Movement>();
    cells = mover.GetCellsInRange(grid);
    grid.SelectCells(cells, SelectionTypes.Move);
  }

  public override void Exit()
  {
    base.Exit();
    grid.DeSelectCells(cells);
    cells = null;
  }

  protected override void OnKeyBoardMove(object sender, InfoEventArgs<CameraDirection> e)
  {
    MoveCamera(e.info);
  }

  protected override void OnMouseMoveEvent(object sender, InfoEventArgs<Vector3> e)
  {
    SelectCell(e.info);
  }

  protected override void OnFire(object sender, InfoEventArgs<int> e)
  {
    if (e.info == 0)
    {
      if (cells.Contains(currentCell))
        owner.ChangeState<ConfirmMoveState>();
    }
  }

}