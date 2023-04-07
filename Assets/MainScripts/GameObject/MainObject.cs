using System;
using System.ComponentModel;
using UnityEngine;

namespace MainScripts.GameObject
{
    public abstract class MainObject : MonoBehaviour
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
        /// <summary>
        /// Имхо у обьекта может быть 3 состояния
        /// </summary>
        public enum States { walk, run, jump }

        public States StateAnimation
        {
            get
            {
                return (States)_animator.GetInteger("state");
            }
            set
            {
                if (!Enum.IsDefined(typeof(States), value))
                    throw new InvalidEnumArgumentException(nameof(value), (int)value, typeof(States));
                _animator.SetInteger("state", (int)value);
            }
        }
        
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
    }
    
}
