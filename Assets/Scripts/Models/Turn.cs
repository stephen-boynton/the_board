using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn {
  public Piece actor;
  public bool hasPieceMoved;
  public bool hasPieceActed;
  public bool lockMove;
  public List<Cell> targets;
  Cell startTile;
  Directions startDir;

  public void Change (Piece current) {
    actor = current;
    hasPieceMoved = false;
    hasPieceActed = false;
    lockMove = false;
    startTile = actor.currentCell;
    startDir = actor.dir;
  }

  public void UndoMove () {
    hasPieceMoved = false;
    actor.Place (startTile);
    actor.dir = startDir;
    actor.Match ();
  }
}