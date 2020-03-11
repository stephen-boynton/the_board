using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBattleState : BattleState
{
  public override void Enter()
  {
    base.Enter();
    StartCoroutine(Init());
  }

  IEnumerator Init()
  {
    SpawnSelector();
    SpawnUnits();
    battleMenu.Hide();
    battleBanner.Hide();
    owner.round = owner.gameObject.AddComponent<TurnOrderController>().Round();
    yield return null;
    owner.ChangeState<SelectPieceState>();
  }

  private void SpawnSelector()
  {
    selector = Instantiate(selector, transform) as GameObject;
    CellSelector cellSelector = selector.GetComponent<CellSelector>();
    currentCell = grid.GetCellByRowAndColumn((int)cellSelector.startingPosition.x, (int)cellSelector.startingPosition.y);
    grid.PlaceInGridNoOccupy(cellSelector.startingPosition, cellSelector.visualOffset, selector);
  }

  private void SpawnUnits()
  {
    foreach (GameObject p in teamOne)
    {
      GameObject pieceGO = Instantiate(p, transform) as GameObject;
      Piece piece = pieceGO.GetComponent<Piece>();
      Cell startingCell = grid.GetCellByRowAndColumn((int)piece.startingPosition.x, (int)piece.startingPosition.y);
      grid.PlaceInGrid(piece.startingPosition, startingCell.heightOffset / 2, pieceGO);
      piece.Place(startingCell);
      Role role = piece.transform.GetComponent<Role>();
      role.LoadStats();
      pieces.Add(piece);
    }
  }
}