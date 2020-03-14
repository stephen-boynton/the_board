using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleBanner : MonoBehaviour
{

  BattleController owner;
  CanvasGroup CG;
  Text teamName;
  Text gamePiece;
  Text HP;
  Turn turn { get { return owner.turn; } }

  private void Awake()
  {
    owner = transform.parent.GetComponentInChildren<BattleController>();
    CG = GetComponentInChildren<CanvasGroup>();
    var Panel = CG.transform.GetChild(0);
    teamName = Panel.GetChild(0).GetComponent<Text>();
    gamePiece = Panel.GetChild(1).GetComponent<Text>();
    HP = Panel.GetChild(2).GetComponent<Text>();
  }
  public void Show()
  {
    CG.alpha = 1;
    CG.interactable = true;
  }

  public void Hide()
  {
    CG.alpha = 0;
    CG.interactable = false;
  }

  public void UpdateInfo(string team, string piece, string hp)
  {
    teamName.text = team;
    gamePiece.text = piece;
    HP.text = hp;
  }

  public void UpdateGamePiece(string piece)
  {
    gamePiece.text = piece;
  }
}