using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSelectionState : BattleState {

  public override void Enter () {
    base.Enter ();
    battleMenu.Show ();
    battleMenu.UpdateMenu ();
    battleBanner.Show ();
    battleBanner.UpdateGamePiece (turn.actor.GetComponent<Piece> ().DisplayName);
  }

  protected override void OnUiPress (object sender, InfoEventArgs<BattleActions> e) {
    if (e.info == BattleActions.Move) {
      battleMenu.Hide ();
      battleBanner.Hide ();
      owner.ChangeState<MoveTargetState> ();
    }

    if (e.info == BattleActions.Wait) {
      battleMenu.Hide ();
      battleBanner.Hide ();
      owner.ChangeState<EndTurnState> ();
    }
  }

  protected override void OnFire (object sender, InfoEventArgs<int> e) {
    if (e.info == 1) {
      battleMenu.Hide ();
      battleBanner.Hide ();
      owner.ChangeState<ExploreState> ();
    }
  }

}