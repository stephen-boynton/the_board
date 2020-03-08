using System.Collections;
using UnityEngine;

public class Role : MonoBehaviour {
  #region Fields / Properties
  Stats stats;
  [SerializeField] int CTR = 1000;
  [SerializeField] int SPD = 500;
  #endregion

  #region Public

  public void LoadStats () {
    stats = GetComponent<Stats> ();
    stats.SetValue (StatTypes.CTR, CTR, true);
    stats.SetValue (StatTypes.SPD, SPD, true);
  }
  #endregion
}