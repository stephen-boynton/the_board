using System.Collections;
using UnityEngine;

public class EndTurnState : BattleState
{
  Directions startDir;

  public override void Enter()
  {
    base.Enter();
    SelectCell(turn.actor.currentCell.positionId);
    SetCamera(turn.actor.currentCell.positionId);
  }

  protected override void OnFire(object sender, InfoEventArgs<int> e)
  {
    switch (e.info)
    {
      case 0:
        owner.ChangeState<SelectPieceState>();
        break;
      case 1:
        turn.actor.dir = startDir;
        owner.ChangeState<CommandSelectionState>();
        break;
    }
  }
}