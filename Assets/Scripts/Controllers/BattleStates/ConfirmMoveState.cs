using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConfirmMoveState : BattleState
{
  List<Cell> cells = new List<Cell>();
  public override void Enter()
  {
    base.Enter();
    cells.Add(currentCell);
    grid.SelectCells(cells, SelectionTypes.Confirm);
  }

  public override void Exit()
  {
    base.Exit();
    grid.DeSelectCells(cells);
    cells = new List<Cell>();
  }

  protected override void OnFire(object sender, InfoEventArgs<int> e)
  {
    if (e.info == 0)
    {
      owner.ChangeState<MoveTransitionState>();
    }
    else
      owner.ChangeState<MoveTargetState>();
  }
}