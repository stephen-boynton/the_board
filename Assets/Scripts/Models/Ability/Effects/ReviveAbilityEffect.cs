﻿using UnityEngine;
using System.Collections;

public class ReviveAbilityEffect : BaseAbilityEffect
{
  public float percent;

  public override int Predict(Cell target)
  {
    Stats s = target.occupant.GetComponent<Stats>();
    return Mathf.FloorToInt(s[StatTypes.MHP] * percent);
  }

  protected override int OnApply(Cell target)
  {
    Stats s = target.occupant.GetComponent<Stats>();
    int value = s[StatTypes.HP] = Predict(target);
    return value;
  }
}