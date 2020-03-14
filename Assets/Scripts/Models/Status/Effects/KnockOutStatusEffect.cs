﻿using UnityEngine;
using System.Collections;

public class KnockOutStatusEffect : StatusEffect
{
  Piece owner;
  Stats stats;

  void Awake()
  {
    owner = GetComponentInParent<Piece>();
    stats = owner.GetComponent<Stats>();
  }

  void OnEnable()
  {
    owner.transform.localScale = new Vector3(0.75f, 0.1f, 0.75f);
    this.AddObserver(OnTurnCheck, TurnOrderController.TurnCheckNotification, owner);
    this.AddObserver(OnStatCounterWillChange, Stats.WillChangeNotification(StatTypes.CTR), stats);
  }

  void OnDisable()
  {
    owner.transform.localScale = Vector3.one;
    this.RemoveObserver(OnTurnCheck, TurnOrderController.TurnCheckNotification, owner);
    this.RemoveObserver(OnStatCounterWillChange, Stats.WillChangeNotification(StatTypes.CTR), stats);
  }

  void OnTurnCheck(object sender, object args)
  {
    // Dont allow a KO'd piece to take turns
    BaseException exc = args as BaseException;
    if (exc.defaultToggle == true)
      exc.FlipToggle();
  }

  void OnStatCounterWillChange(object sender, object args)
  {
    // Dont allow a KO'd piece to increment the turn order counter
    ValueChangeException exc = args as ValueChangeException;
    if (exc.toValue > exc.fromValue)
      exc.FlipToggle();
  }
}