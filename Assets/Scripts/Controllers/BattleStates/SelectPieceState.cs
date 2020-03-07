using System.Collections;
using UnityEngine;

public class SelectPieceState : BattleState {
  public override void Enter () {
    base.Enter ();
    StartCoroutine (ChangeCurrentUnit ());
  }

  public override void Exit () {
    base.Exit ();
  }

  IEnumerator ChangeCurrentUnit () {
    owner.round.MoveNext ();
    SelectCell (turn.actor.currentCell.transform.position);
    yield return null;
    owner.ChangeState<MoveTargetState> ();
  }
}