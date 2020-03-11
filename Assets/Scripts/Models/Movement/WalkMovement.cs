using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkMovement : Movement
{
  #region Protected
  protected override bool ExpandSearch(Cell from, Cell to)
  {

    // Skip if the distance in height between the two tiles is more than the unit can jump
    if ((Mathf.Abs(from.height - to.height) > jumpHeight))
      return false;

    // Skip if the cell is occupied by an enemy
    if (to.occupant != null)
      return false;

    return base.ExpandSearch(from, to);
  }

  public override IEnumerator Traverse(Cell cell)
  {
    piece.Place(cell);

    // Build a list of way points from the piece's 
    // starting cell to the destination cell
    List<Cell> targets = new List<Cell>();
    while (cell != null)
    {
      targets.Insert(0, cell);
      cell = cell.prev;
    }

    // Move to each way point in succession
    for (int i = 1; i < targets.Count; ++i)
    {
      Cell from = targets[i - 1];
      Cell to = targets[i];

      Directions dir = from.GetDirection(to);
      if (piece.dir != dir)
      {
        yield return StartCoroutine(Turn(dir));
      }

      if (from.height == to.height)
        yield return StartCoroutine(Walk(to));
      else
        yield return StartCoroutine(Jump(to));
    }

    yield return null;
  }
  #endregion

  #region Private
  IEnumerator Walk(Cell target)
  {
    Vector3 targetCenter = new Vector3(target.center.x, transform.position.y, target.center.y);
    Tweener tweener = transform.MoveTo(targetCenter, 0.3f, EasingEquations.Linear);
    while (tweener != null)
      yield return null;
  }

  IEnumerator Jump(Cell to)
  {
    Tweener tweener = transform.MoveTo(to.center, 0.5f, EasingEquations.Linear);

    Tweener t2 = jumper.MoveToLocal(new Vector3(0, Cell.STEP_HEIGHT * 2f, 0), tweener.easingControl.duration / 2f, EasingEquations.EaseOutQuad);
    t2.easingControl.loopCount = 1;
    t2.easingControl.loopType = EasingControl.LoopType.PingPong;

    while (tweener != null)
      yield return null;
  }
  #endregion
}