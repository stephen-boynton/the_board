using UnityEngine;
using System.Collections;

public abstract class HitRate : MonoBehaviour
{
  #region Notifications
  /// <summary>
  /// Includes a toggleable MatchException argument which defaults to false.
  /// </summary>
  public const string AutomaticHitCheckNotification = "HitRate.AutomaticHitCheckNotification";

  /// <summary>
  /// Includes a toggleable MatchException argument which defaults to false.
  /// </summary>
  public const string AutomaticMissCheckNotification = "HitRate.AutomaticMissCheckNotification";

  /// <summary>
  /// Includes an Info argument with three parameters: Attacker (Piece), Defender (Piece), 
  /// and Defender's calculated Evade / Resistance (int).  Status effects which modify Hit Rate
  /// should modify the arg2 parameter.
  /// </summary>
  public const string StatusCheckNotification = "HitRate.StatusCheckNotification";
  #endregion

  #region Fields
  public virtual bool IsAngleBased { get { return true; } }
  protected Piece attacker;
  #endregion

  #region MonoBehaviour
  protected virtual void Start()
  {
    attacker = GetComponentInParent<Piece>();
  }
  #endregion

  #region Public
  /// <summary>
  /// Returns a value in the range of 0 t0 100 as a percent chance of
  /// an ability succeeding to hit
  /// </summary>
  public abstract int Calculate(Cell target);

  public virtual bool RollForHit(Cell target)
  {
    int roll = UnityEngine.Random.Range(0, 101);
    int chance = Calculate(target);
    return roll <= chance;
  }
  #endregion

  #region Protected
  protected virtual bool AutomaticHit(Piece target)
  {
    MatchException exc = new MatchException(attacker, target);
    this.PostNotification(AutomaticHitCheckNotification, exc);
    return exc.toggle;
  }

  protected virtual bool AutomaticMiss(Piece target)
  {
    MatchException exc = new MatchException(attacker, target);
    this.PostNotification(AutomaticMissCheckNotification, exc);
    return exc.toggle;
  }

  protected virtual int AdjustForStatusEffects(Piece target, int rate)
  {
    Info<Piece, Piece, int> args = new Info<Piece, Piece, int>(attacker, target, rate);
    this.PostNotification(StatusCheckNotification, args);
    return args.arg2;
  }

  protected virtual int Final(int evade)
  {
    return 100 - evade;
  }
  #endregion
}