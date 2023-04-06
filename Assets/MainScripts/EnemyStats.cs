using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyStats : MonoBehaviour
{
    private float MaxHp;

    private float HealthPoints;

    private float Speed;

    private float Damage;

    private float AttackRange;

    private float Armor;

    private float SpeedAttack;

    private float HpRegeneration;

    public virtual float healthPoints
    {
        get { return HealthPoints; }
        set { HealthPoints = value > MaxHp ? MaxHp : value; }
    }

    public virtual float speed
    {
        get { return Speed; }
        set { Speed = value; }
    }

    public virtual float maxHP
    {
        get { return MaxHp; }
        set { MaxHp = value; }
    }

    public virtual float damage
    {
        get { return Damage; }
        set { Damage = value; }
    }

    public virtual float attackRange
    {
        get { return AttackRange; }
        set { AttackRange = value; }
    }

    public virtual float armor
    {
        get { return Armor; }
        set { Armor = value; }
    }

    public virtual float speedAttack
    {
        get { return SpeedAttack; }
        set { SpeedAttack = value; }
    }

    public virtual float healthPointsRegeneration
    {
        get { return HpRegeneration; }
        set { HpRegeneration = value; }
    }
}
