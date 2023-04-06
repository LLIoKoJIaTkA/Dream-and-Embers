using MainScripts.GameObject;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : EnemyStats
{
    [Header("Enemy Stats")]
    #region statsFromTheMainObjects
    public new float maxHP = 100f;
    public new float healthPoints = 100f;
    public new float speed = 1f;
    public new float damage = 10f;
    public new float speedAttack = 3f;
    public new float healthPointsRegeneration = 10f;
    #endregion statsFromTheMainObjects

    #region statsFromTheEnemyObjects
    public float speedMultiplier = 0.05f;
    public float fieldOfView = 10f;
    #endregion statsFromTheEnemyObjects
}