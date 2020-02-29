using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = 0.5f;
    private int selectionX = -1;
    private int selectionY = -1;
    private float HEIGHT_SIZE = 0.3f;

    [SerializeField] GameObject SquarePreset;
    [SerializeField] GameObject SquarePrefab;
    [SerializeField] Piece Protect_1;
    [SerializeField] Piece Control_1;
    [SerializeField] Piece Destroy_1;
    [SerializeField] Piece Protect_2;
    [SerializeField] Piece Control_2;
    [SerializeField] Piece Destroy_2;
    [SerializeField] int size = 8;

    private int START_ROW = 0;
    private int END_ROW;

    private Square[, ] Squares;

    private void Start () {
        Init ();
        SpawnAllTiles ();
        SpawnAllPieces ();
    }

    private void Update () {
        DrawChessboard ();
        UpdateSelection ();
    }

    private void Init () {
        END_ROW = size - 1;
        Squares = new Square[size, size];
    }

    private void UpdateSelection () {
        if (!Camera.main)
            return;

        RaycastHit hit;

        if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit, 40.0f, LayerMask.GetMask ("BoardPlane"))) {
            selectionX = (int) hit.point.x;
            selectionY = (int) hit.point.z;
        } else {
            selectionY = -1;
            selectionX = -1;
        }
    }

    private void SpawnPiece (Piece piece, int x, int y) {
        Vector3 center = GetTileCenter (x, y);
        center.y = HEIGHT_SIZE;
        Piece go = Instantiate (piece, center, Quaternion.identity) as Piece;
        go.transform.SetParent (transform);
        go.location = new PositionId (x, y);
    }

    private void BuildTeamOne () {

        // Protect
        SpawnPiece (Protect_1, 3, START_ROW);

        // Control
        SpawnPiece (Control_1, 2, START_ROW);

        // Destroy
        SpawnPiece (Destroy_1, 1, START_ROW);
    }

    private void BuildTeamTwo () {

        // Protect
        SpawnPiece (Protect_2, 3, END_ROW);

        // Control
        SpawnPiece (Control_2, 2, END_ROW);

        // Destroy
        SpawnPiece (Destroy_2, 1, END_ROW);

        foreach (Piece p in (new List<Piece> () { Protect_2, Control_2, Destroy_2 })) {
            MyUtility.RotateGameObject (p, new Vector3 (0, 180, 0));
        }
    }

    private void SpawnAllPieces () {
        BuildTeamOne ();
        BuildTeamTwo ();
    }

    private void SpawnAllTiles () {
        for (int i = 0; i < size; i++) {
            for (int j = 0; j < size; j++) {
                Vector3 center = GetTileCenter (i, j);
                GameObject goS = Instantiate (SquarePrefab, center, Quaternion.identity);
                Square s = goS.AddComponent<Square> ();
                s.coordinates = new Vector2 (center.x, center.z);
                s.height = 0;
                s.positionId = new PositionId (i, j);
                Squares[i, j] = s;
                goS.transform.SetParent (transform);
            }
        }
    }

    private Vector3 GetTileCenter (int x, int y) {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * y) + TILE_OFFSET;
        return origin;
    }
    private void DrawChessboard () {
        Vector3 widthLine = Vector3.right * size;
        Vector3 heightLine = Vector3.forward * size;

        for (int i = 0; i <= size; i++) {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine (start, start + widthLine);
            for (int j = 0; j <= size; j++) {
                start = Vector3.right * j;
                Debug.DrawLine (start, start + heightLine);
            }
        }

        // Draw Selection
        if (selectionX >= 0 && selectionY >= 0) {
            Debug.DrawLine (
                Vector3.forward * selectionY + Vector3.right * selectionX,
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1)
            );

            Debug.DrawLine (
                Vector3.forward * (selectionY + 1) + Vector3.right * selectionX,
                Vector3.forward * selectionY + Vector3.right * (selectionX + 1)
            );
        }
    }
}