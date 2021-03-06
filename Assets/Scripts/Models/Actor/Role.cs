using System.Collections;
using UnityEngine;

public class Role : MonoBehaviour
{
  #region Fields / Properties
  Stats stats;
  [SerializeField] int CTR = 1000;
  [SerializeField] int SPD = 500;
  [SerializeField] int MOV = 10;
  [SerializeField] int JMP = 5;
  [SerializeField] int HP = 100;
  [SerializeField] int MHP = 100;
  [SerializeField] int ATK = 10;
  #endregion

  #region Public

  public void LoadStats()
  {
    stats = GetComponent<Stats>();
    stats.SetValue(StatTypes.CTR, CTR, true);
    stats.SetValue(StatTypes.SPD, SPD, true);
    stats.SetValue(StatTypes.MOV, MOV, true);
    stats.SetValue(StatTypes.JMP, JMP, true);
    stats.SetValue(StatTypes.HP, HP, true);
    stats.SetValue(StatTypes.MHP, MHP, false);
    stats.SetValue(StatTypes.ATK, ATK, true);
  }
  #endregion
}