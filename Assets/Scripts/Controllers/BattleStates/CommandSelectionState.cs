using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandSelectionState : BattleState
{
  public override void Enter()
  {
    base.Enter();

    Piece p = turn.actor.GetComponent<Piece>();
    Stats s = p.GetComponent<Stats>();
    string HP = s[StatTypes.HP].ToString() + '/' + s[StatTypes.MHP].ToString();
    battleMenu.Show();
    battleMenu.UpdateMenu();
    battleBanner.Show();
    battleBanner.UpdateInfo(
      "Green Team",
      p.DisplayName,
      HP
      );
  }

  protected override void OnUiPress(object sender, InfoEventArgs<BattleActions> e)
  {
    if (e.info == BattleActions.Move)
    {
      battleMenu.Hide();
      battleBanner.Hide();
      owner.ChangeState<MoveTargetState>();
    }

    if (e.info == BattleActions.Attack)
    {
      battleMenu.Hide();
      battleBanner.Hide();
      turn.ability = turn.actor.GetComponentInChildren<Ability>();
      owner.ChangeState<AttackSelectionState>();
    }

    if (e.info == BattleActions.Wait)
    {
      battleMenu.Hide();
      battleBanner.Hide();
      owner.ChangeState<EndTurnState>();
    }
  }

  protected override void OnFire(object sender, InfoEventArgs<int> e)
  {
    if (e.info == 1)
    {
      battleMenu.Hide();
      battleBanner.Hide();
      owner.ChangeState<ExploreState>();
    }
  }

}