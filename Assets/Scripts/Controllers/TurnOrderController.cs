using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrderController : MonoBehaviour {
  #region Constants
  const int turnActivation = 1000;
  const int turnCost = 500;
  const int moveCost = 300;
  const int actionCost = 200;
  #endregion

  #region Notifications
  public const string RoundBeganNotification = "TurnOrderController.roundBegan";
  public const string TurnCheckNotification = "TurnOrderController.turnCheck";
  public const string TurnBeganNotification = "TurnOrderController.TurnBeganNotification";
  public const string TurnCompletedNotification = "TurnOrderController.turnCompleted";
  public const string RoundEndedNotification = "TurnOrderController.roundEnded";
  #endregion

  #region Public
  public IEnumerator Round () {
    BattleController bc = GetComponent<BattleController> ();;
    while (true) {
      this.PostNotification (RoundBeganNotification);

      List<Piece> pieces = new List<Piece> (bc.pieces);
      for (int i = 0; i < pieces.Count; ++i) {
        Stats s = pieces[i].GetComponent<Stats> ();
        s[StatTypes.CTR] += s[StatTypes.SPD];
      }

      pieces.Sort ((a, b) => GetCounter (a).CompareTo (GetCounter (b)));

      for (int i = pieces.Count - 1; i >= 0; --i) {
        if (CanTakeTurn (pieces[i])) {
          bc.turn.Change (pieces[i]);
          pieces[i].PostNotification (TurnBeganNotification);

          yield return pieces[i];

          int cost = turnCost;
          if (bc.turn.hasPieceMoved)
            cost += moveCost;
          if (bc.turn.hasPieceActed)
            cost += actionCost;

          Stats s = pieces[i].GetComponent<Stats> ();
          s.SetValue (StatTypes.CTR, s[StatTypes.CTR] - cost, false);

          pieces[i].PostNotification (TurnCompletedNotification);
        }
      }

      this.PostNotification (RoundEndedNotification);
    }
  }
  #endregion

  #region Private
  bool CanTakeTurn (Piece target) {
    BaseException exc = new BaseException (GetCounter (target) >= turnActivation);
    target.PostNotification (TurnCheckNotification, exc);
    return exc.toggle;
  }

  int GetCounter (Piece target) {
    return target.GetComponent<Stats> () [StatTypes.CTR];
  }
  #endregion
}