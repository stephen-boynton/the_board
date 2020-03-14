using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenu : MonoBehaviour
{

  BattleController owner;
  CanvasGroup CG;
  Turn turn { get { return owner.turn; } }

  [SerializeField] public Button MoveButton;
  [SerializeField] public Button AttackButton;

  private void Awake()
  {
    owner = transform.parent.GetComponentInChildren<BattleController>();
    CG = GetComponentInChildren<CanvasGroup>();
  }

  public void UpdateMenu()
  {
    if (!turn.hasPieceMoved)
    {
      MoveButton.interactable = true;
    }
    else
    {
      MoveButton.interactable = false;
    }

    if (!turn.hasPieceActed)
    {
      AttackButton.interactable = true;
    }
    else
    {
      AttackButton.interactable = false;
    }
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
}