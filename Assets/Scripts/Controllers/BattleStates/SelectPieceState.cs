using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPieceState : BattleState
{
  List<Cell> cells = new List<Cell>();

  public override void Enter()
  {
    base.Enter();
    Debug.Log("Select Piece!");
  }

  protected override void OnKeyBoardMove(object sender, InfoEventArgs<CameraDirection> e)
  {
    MoveCamera(e.info);
  }

  protected override void OnMouseMoveEvent(object sender, InfoEventArgs<Vector3> e)
  {
    SelectCell(e.info);
  }

  protected override void OnFire(object sender, InfoEventArgs<int> e)
  {
    if (currentCell.occupant == teamOne[0])
    {
      Debug.Log("Yippeeeee!");
      owner.ChangeState<MoveTargetState>();
    }
  }


}