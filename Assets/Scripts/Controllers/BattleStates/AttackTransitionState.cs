using UnityEngine;
using System.Collections;

public class AttackTransitionState : BattleState
{
  public override void Enter()
  {
    base.Enter();
    turn.hasPieceActed = true;
    if (turn.hasPieceMoved)
      turn.lockMove = true;

    StartCoroutine(Animate());
  }

  IEnumerator Animate()
  {
    // TODO play animations, etc
    yield return null;
    ApplyAbility();

    // if (IsBattleOver())
    //   owner.ChangeState<CutSceneState>();
    // else if (!UnitHasControl())
    //   owner.ChangeState<SelectUnitState>();
    // else if (turn.hasUnitMoved)
    //   owner.ChangeState<EndFacingState>();
    // else
    owner.ChangeState<CommandSelectionState>();
  }

  void ApplyAbility()
  {
    turn.ability.Perform(turn.targets);
  }

  // bool UnitHasControl()
  // {
  //   return turn.actor.GetComponentInChildren<KnockOutStatusEffect>() == null;
  // }
}