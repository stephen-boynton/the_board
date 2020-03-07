using UnityEngine;
using System.Collections;

public class MoveTransitionState : BattleState
{
  public override void Enter()
  {
    base.Enter();
    StartCoroutine(Sequence());
  }

  IEnumerator Sequence()
  {
    Movement mover = teamOne[0].GetComponent<Movement>();
    yield return StartCoroutine(mover.Traverse(currentCell));
    owner.ChangeState<SelectPieceState>();
  }
}