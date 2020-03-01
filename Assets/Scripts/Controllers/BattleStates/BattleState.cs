using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class BattleState : State
{
    protected BattleController owner;
    public Cell currentCell;
    public CellSelector selector { get { return owner.selector; } private set { } }
    public GridManager grid { get { return owner.grid; } }

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

    //protected virtual void SelectTile(Point p)
    //{
    //	if (pos == p || !board.tiles.ContainsKey(p))
    //		return;

    //	pos = p;
    //	tileSelectionIndicator.localPosition = board.tiles[p].center;
    //}

    //protected virtual Unit GetUnit(Point p)
    //{
    //	Tile t = board.GetTile(p);
    //	GameObject content = t != null ? t.content : null;
    //	return content != null ? content.GetComponent<Unit>() : null;
    //}

    //protected virtual void RefreshPrimaryStatPanel(Point p)
    //{
    //	Unit target = GetUnit(p);
    //	if (target != null)
    //		statPanelController.ShowPrimary(target.gameObject);
    //	else
    //		statPanelController.HidePrimary();
    //}

    //protected virtual void RefreshSecondaryStatPanel(Point p)
    //{
    //	Unit target = GetUnit(p);
    //	if (target != null)
    //		statPanelController.ShowSecondary(target.gameObject);
    //	else
    //		statPanelController.HideSecondary();
    //}

    //protected virtual bool DidPlayerWin()
    //{
    //	return owner.GetComponent<BaseVictoryCondition>().Victor == Alliances.Hero;
    //}

    //protected virtual bool IsBattleOver()
    //{
    //	return owner.GetComponent<BaseVictoryCondition>().Victor != Alliances.None;
    //}
}