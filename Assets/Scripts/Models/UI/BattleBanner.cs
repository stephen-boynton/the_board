using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleBanner : MonoBehaviour {

  BattleController owner;
  CanvasGroup CG;
  Text teamName;
  Text gamePiece;
  Turn turn { get { return owner.turn; } }

  private void Awake () {
    owner = transform.parent.GetComponentInChildren<BattleController> ();
    CG = GetComponentInChildren<CanvasGroup> ();
    var Panel = CG.transform.GetChild (0);
    teamName = Panel.GetChild (0).GetComponent<Text> ();
    gamePiece = Panel.GetChild (1).GetComponent<Text> ();
  }
  public void Show () {
    CG.alpha = 1;
    CG.interactable = true;
  }

  public void Hide () {
    CG.alpha = 0;
    CG.interactable = false;
  }

  public void UpdateInfo (string team, string piece) {
    teamName.text = team;
    gamePiece.text = piece;
  }

  public void UpdateGamePiece (string piece) {
    gamePiece.text = piece;
  }
}