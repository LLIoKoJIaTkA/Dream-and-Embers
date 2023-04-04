using System;
using System.ComponentModel;
using UnityEngine;

namespace MainScripts.GameObject
{
    public class MainObject : MonoBehaviour
    {
        public float HealthPoints = 100f;

        public float Speed = 10f;
    
        public float MaxHp = 100f;
    
        public float Damage = 25f;
    
        public float AttackRange = 10f;
    
        public float Armor = 5f;

        public float SpeedAttack = 1f;

        public float HpRegeneration = 5f;
        
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
