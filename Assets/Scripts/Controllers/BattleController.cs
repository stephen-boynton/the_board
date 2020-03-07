using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : StateMachine
{
  public GridManager grid;
  [SerializeField] public GameObject selector;
  [SerializeField] public GameObject cameraRig;
  [SerializeField] public List<GameObject> TeamOne = new List<GameObject>();
  [SerializeField] public List<GameObject> TeamTwo = new List<GameObject>();

  public Cell currentCell;


  private void Awake()
  {
    grid = GetComponentInParent<GridManager>();
    selector = Instantiate(selector, transform) as GameObject;
    TeamOne[0] = Instantiate(TeamOne[0], transform) as GameObject;
  }

  void Start()
  {
    ChangeState<InitBattleState>();
  }
}