using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttackSelectionState : BattleState
{
  List<Cell> cells;
  AbilityRange ar;
  int debounceFire = 0;

  public override void Enter()
  {
    base.Enter();
    ar = turn.ability.GetComponent<AbilityRange>();
    SelectCells();
  }

  public override void Exit()
  {
    base.Exit();
    grid.DeSelectCells(cells);
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
      debounceFire++;
      if (debounceFire > 1)
      {
        if (cells.Contains(currentCell))
        {
          debounceFire = 0;
          owner.ChangeState<ConfirmAttackAreaState>();

        }
      }
    }
    else
    {
      debounceFire = 0;
      owner.ChangeState<CommandSelectionState>();
    }
  }

  // void ChangeDirection(PositionId p)
  // {
  //   Directions dir = p.GetDirection();
  //   if (turn.actor.dir != dir)
  //   {
  //     grid.DeSelectCells(cells);
  //     turn.actor.dir = dir;
  //     turn.actor.Match();
  //     SelectCells();
  //   }
  // }

  void SelectCells()
  {
    cells = ar.GetTilesInRange(grid);
    grid.SelectCells(cells, SelectionTypes.Attack);
  }
}