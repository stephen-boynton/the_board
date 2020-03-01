using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : StateMachine
{
  public GridManager grid;
  [SerializeField] public CellSelector selector;
  [SerializeField] List<Piece> TeamOne = new List<Piece>();
  [SerializeField] List<Piece> TeamTwo = new List<Piece>();

    private void Awake()
    {
        grid = GetComponentInParent<GridManager>();
        selector = Instantiate(selector, transform);
    }

    void Start()
    {
        ChangeState<InitBattleState>();
    }
}