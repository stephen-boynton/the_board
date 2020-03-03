using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class BattleState : State
{
    protected BattleController owner;
    public Cell currentCell;
    public GameObject selector { get { return owner.selector; } private set { } }
    public GridManager grid { get { return owner.grid; } }
    public List<GameObject> teamOne {get { return owner.TeamOne; }}

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

    protected virtual void OnKeyBoardMove(object sender, InfoEventArgs<Vector3> e)
    {

    }

    protected virtual void OnFire(object sender, InfoEventArgs<int> e)
    {

    }

    protected virtual void OnMouseMoveEvent(object sender, InfoEventArgs<Vector3> e)
    {

    }
}