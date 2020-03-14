using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : StateMachine
{
  public GridManager grid;
  [SerializeField] public GameObject selector;
  [SerializeField] public GameObject cameraRig;
  [SerializeField] public BattleMenu battleMenu;
  [SerializeField] public BattleBanner battleBanner;
  [SerializeField] public AbilityPanel abilityPanel;
  [SerializeField] public List<GameObject> TeamOne = new List<GameObject>();
  [SerializeField] public List<GameObject> TeamTwo = new List<GameObject>();
  public List<Piece> pieces = new List<Piece>();
  public Cell currentCell;
  public IEnumerator round;
  public Turn turn = new Turn();
  private void Awake()
  {
    grid = GetComponentInParent<GridManager>();
  }

  void Start()
  {
    ChangeState<InitBattleState>();
  }
}