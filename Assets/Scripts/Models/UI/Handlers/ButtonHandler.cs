using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
  public static event EventHandler<InfoEventArgs<BattleActions>> uiPress;

  public void MoveButtonHandler()
  {
    uiPress(this, new InfoEventArgs<BattleActions>(BattleActions.Move));
  }

  public void WaitButtonHandler()
  {
    uiPress(this, new InfoEventArgs<BattleActions>(BattleActions.Wait));
  }

  public void AttackButtonHandler()
  {
    uiPress(this, new InfoEventArgs<BattleActions>(BattleActions.Attack));
  }
}