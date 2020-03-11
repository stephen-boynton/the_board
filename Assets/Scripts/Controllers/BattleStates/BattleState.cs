using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BattleState : State
{
  protected BattleController owner;
  public GameObject selector { get { return owner.selector; } set { owner.selector = value; } }
  public Cell currentCell { get { return owner.currentCell; } set { owner.currentCell = value; } }
  public GridManager grid { get { return owner.grid; } }
  public List<GameObject> teamOne { get { return owner.TeamOne; } }
  public List<Piece> pieces { get { return owner.pieces; } }
  public Turn turn { get { return owner.turn; } }
  public BattleMenu battleMenu { get { return owner.battleMenu; } }
  public BattleBanner battleBanner { get { return owner.battleBanner; } }
  public GameObject cameraRig { get { return owner.cameraRig; } }
  protected virtual void Awake()
  {
    owner = GetComponent<BattleController>();
  }

  protected override void AddListeners()
  {
    InputController.mouseMoveEvent += OnMouseMoveEvent;
    InputController.keyboardMoveEvent += OnKeyBoardMove;
    InputController.fireEvent += OnFire;
    ButtonHandler.uiPress += OnUiPress;
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

  protected virtual void OnUiPress(object sender, InfoEventArgs<BattleActions> e)
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
        currentCell.heightOffset + selector.GetComponent<CellSelector>().visualOffset,
        currentCell.center.y
      );
    }
  }

  protected virtual void SelectCell(PositionId pos)
  {
    Cell hoveredCell = grid.GetCellByPositionId(pos);
    if (hoveredCell != currentCell)
    {
      currentCell = hoveredCell;
      selector.transform.position = new Vector3(
        currentCell.center.x,
        currentCell.heightOffset + selector.GetComponent<CellSelector>().visualOffset,
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

  protected virtual void SetCamera(PositionId pos)
  {
    Cell cell = grid.GetCellByPositionId(pos);
    Vector3 center = new Vector3(cell.center.x, 0, cell.center.y);
    cameraRig.transform.position = center;
  }
}