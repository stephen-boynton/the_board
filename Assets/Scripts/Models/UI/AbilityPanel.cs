using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AbilityPanel : MonoBehaviour
{

  BattleController owner;
  CanvasGroup CG;

  [SerializeField] Text pieceName;
  [SerializeField] Text pieceStartHP;
  [SerializeField] Text pieceEndHP;
  Turn turn { get { return owner.turn; } }

  private void Awake()
  {
    owner = transform.parent.GetComponentInChildren<BattleController>();
    CG = GetComponentInChildren<CanvasGroup>();
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

  public void UpdateInfo(string name, string startHp, string EndHp)
  {
    pieceName.text = name;
    pieceStartHP.text = startHp;
    pieceEndHP.text = EndHp;
  }
}