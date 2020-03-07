using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class BattleState : State
{
  protected BattleController owner;
  public GameObject selector { get { return owner.selector; } private set { } }
  public Cell currentCell { get { return owner.currentCell; } set { owner.currentCell = value; } }
  public GridManager grid { get { return owner.grid; } }
  public List<GameObject> teamOne { get { return owner.TeamOne; } }

  protected virtual void Awake()
  {
    owner = GetComponent<BattleController>();
  }

  protected override void AddListeners()
  {
    InputController.mouseMoveEvent += OnMouseMoveEvent;
    InputController.keyboardMoveEvent += OnKeyBoardMove;
    InputController.fireEvent += OnFire;
  }

  protected override void RemoveListeners()
  {
    InputController.mouseMoveEvent -= OnMouseMoveEvent;
    InputController.keyboardMoveEvent -= OnKeyBoardMove;
    InputController.fireEvent -= OnFire;
  }

  public override void Enter()
  {
    base.Enter();
  }

  protected virtual void OnKeyBoardMove(object sender, InfoEventArgs<CameraDirection> e)
  {

  }

  protected virtual void OnFire(object sender, InfoEventArgs<int> e)
  {

  }

  protected virtual void OnMouseMoveEvent(object sender, InfoEventArgs<Vector3> e)
  {

  }

  protected virtual void SelectCell(Vector3 pos)
  {
    Cell hoveredCell = grid.GetCellByWorldLocation(pos);
    if (hoveredCell != currentCell)
    {
      currentCell = hoveredCell;
      selector.transform.position = new Vector3(
        currentCell.center.x,
        currentCell.cellHeightOffset + selector.GetComponent<CellSelector>().visualOffset,
        currentCell.center.y
      );
    }
  }

  protected virtual void MoveCamera(CameraDirection pos)
  {
    if (pos == CameraDirection.forward)
      owner.cameraRig.transform.Translate(Vector3.forward * Time.deltaTime * 20, Space.Self);
    else if (pos == CameraDirection.backward)
      owner.cameraRig.transform.Translate(-Vector3.forward * Time.deltaTime * 20, Space.Self);

    if (pos == CameraDirection.left)
      owner.cameraRig.transform.Translate(Vector3.left * Time.deltaTime * 20, Space.Self);
    else if (pos == CameraDirection.right)
      owner.cameraRig.transform.Translate(-Vector3.left * Time.deltaTime * 20, Space.Self);
  }
}