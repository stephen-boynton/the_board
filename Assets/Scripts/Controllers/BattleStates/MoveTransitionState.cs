using System.Collections;
using UnityEngine;

public class MoveTransitionState : BattleState {
  public override void Enter () {
    base.Enter ();
    StartCoroutine (Sequence ());
  }

  IEnumerator Sequence () {
    Movement mover = turn.actor.GetComponent<Movement> ();
    yield return StartCoroutine (mover.Traverse (currentCell));
    owner.ChangeState<SelectPieceState> ();
  }
}