using UnityEngine;
using System.Collections;

public class FlyMovement : Movement
{
  public override IEnumerator Traverse(Cell cell)
  {
    // Store the distance between the start cell and target cell
    float dist = Mathf.Sqrt(Mathf.Pow(cell.positionId.row - piece.currentCell.positionId.row, 2) + Mathf.Pow(cell.positionId.column - piece.currentCell.positionId.column, 2));
    piece.Place(cell);

    // Fly high enough not to clip through any ground cells
    float y = Cell.STEP_HEIGHT * 10;
    float duration = (y - jumper.position.y) * 0.5f;
    Tweener tweener = jumper.MoveToLocal(new Vector3(0, y, 0), duration, EasingEquations.EaseInOutQuad);
    while (tweener != null)
      yield return null;

    // Turn to face the general direction
    Directions dir;
    Vector3 toCell = (new Vector3(cell.center.x, 0, cell.center.y) - new Vector3(transform.position.x, 0, transform.position.z));
    if (Mathf.Abs(toCell.x) > Mathf.Abs(toCell.z))
      dir = toCell.x > 0 ? Directions.East : Directions.West;
    else
      dir = toCell.z > 0 ? Directions.North : Directions.South;
    yield return StartCoroutine(Turn(dir));

    // Move to the correct position
    duration = dist * 0.5f;
    tweener = transform.MoveTo(cell.center, duration, EasingEquations.EaseInOutQuad);
    while (tweener != null)
      yield return null;

    // Land
    duration = (y - cell.center.y) * 0.5f;
    tweener = jumper.MoveToLocal(Vector3.zero, 0.5f, EasingEquations.EaseInOutQuad);
    while (tweener != null)
      yield return null;
  }
}