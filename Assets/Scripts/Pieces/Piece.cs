using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour {
    public int CurrentX { set; get; }
    public int CurrentY { set; get; }
    public bool isTeam1;

    // public abstract void Move ();
    // public abstract void Attack ();
    // public abstract void Turn ();

}