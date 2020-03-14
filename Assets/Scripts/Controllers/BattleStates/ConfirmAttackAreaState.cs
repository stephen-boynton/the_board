using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConfirmAttackAreaState : BattleState
{
  List<Cell> cells;
  AbilityArea aa;
  int index = 0;

  public override void Enter()
  {
    base.Enter();
    aa = turn.ability.GetComponent<AbilityArea>();
    cells = aa.GetTilesInArea(grid, currentCell.positionId);
    grid.SelectCells(cells, SelectionTypes.Confirm);
    FindTargets();

    if (turn.targets.Count > 0 && turn.targets[0].occupant != null)
    {
      Cell targetCell = turn.targets[0];
      Piece mainTarget = targetCell.occupant.GetComponent<Piece>();
      Stats s = mainTarget.GetComponent<Stats>();
      AbilityEffectTarget targeter = turn.ability.transform.GetChild(0).GetComponent<AbilityEffectTarget>();
      BaseAbilityEffect effect = targeter.GetComponent<BaseAbilityEffect>();
      int damage = effect.Predict(targetCell);

      abilityPanel.UpdateInfo(
        mainTarget.DisplayName,
        s[StatTypes.HP].ToString(),
        (s[StatTypes.HP] + damage).ToString()
      );

      abilityPanel.Show();
    }

    if (turn.targets.Count > 0)
    {
      SetTarget(0);
    }
  }

  public override void Exit()
  {
    base.Exit();
    grid.DeSelectCells(cells);
  }

  protected override void OnMouseMoveEvent(object sender, InfoEventArgs<Vector3> e)
  {
    if (e.info.y > 0 || e.info.x > 0)
      SetTarget(index + 1);
    else
      SetTarget(index - 1);
  }

  protected override void OnFire(object sender, InfoEventArgs<int> e)
  {
    if (e.info == 0)
    {
      if (turn.targets.Count > 0)
      {
        abilityPanel.Hide();
        owner.ChangeState<AttackTransitionState>();
      }
    }
    else
      owner.ChangeState<AttackSelectionState>();
  }

  void FindTargets()
  {
    turn.targets = new List<Cell>();
    for (int i = 0; i < cells.Count; ++i)
      if (turn.ability.IsTarget(cells[i]))
        turn.targets.Add(cells[i]);
  }

  void SetTarget(int target)
  {
    index = target;
    if (index < 0)
      index = turn.targets.Count - 1;
    if (index >= turn.targets.Count)
      index = 0;
  }
}