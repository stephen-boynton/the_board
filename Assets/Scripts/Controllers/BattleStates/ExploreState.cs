using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreState : BattleState {

  public override void Enter () {
    base.Enter ();
  }

  protected override void OnKeyBoardMove (object sender, InfoEventArgs<CameraDirection> e) {
    MoveCamera (e.info);
  }

  protected override void OnMouseMoveEvent (object sender, InfoEventArgs<Vector3> e) {
    SelectCell (e.info);
  }

  protected override void OnFire (object sender, InfoEventArgs<int> e) {
    if (e.info == 0) {
      if (currentCell.occupant == turn.actor.gameObject)
        owner.ChangeState<CommandSelectionState> ();
    }

    if (e.info == 1) {
      SelectCell (turn.actor.currentCell.positionId);
      SetCamera (turn.actor.currentCell.positionId);
      owner.ChangeState<CommandSelectionState> ();
    }
  }

}