using UnityEngine;
using System.Collections;

public class HealAbilityEffect : BaseAbilityEffect
{
  public override int Predict(Cell target)
  {
    Piece attacker = GetComponentInParent<Piece>();
    Piece defender = target.occupant.GetComponent<Piece>();
    return GetStat(attacker, defender, GetPowerNotification, 0);
  }

  protected override int OnApply(Cell target)
  {
    Piece defender = target.occupant.GetComponent<Piece>();

    // Start with the predicted value
    int value = Predict(target);

    // Add some random variance
    value = Mathf.FloorToInt(value * UnityEngine.Random.Range(0.9f, 1.1f));

    // Clamp the amount to a range
    value = Mathf.Clamp(value, minDamage, maxDamage);

    // Apply the amount to the target
    Stats s = defender.GetComponent<Stats>();
    s[StatTypes.HP] += value;
    return value;
  }
}