using MainScripts.Animation;
using System.Runtime.ExceptionServices;
using UnityEngine;

namespace MainScripts.Stats
{
    public class HeroStats : MonoBehaviour
    {
        private float _healthPoints = 100f;
        private float _maxHealthPoints = 100f;
        private float _damage = 25f;
        private float _attackRange = 1.417f;
        private float _armor = 5f;
        private float _speedAttack = 1f;
        private float _jumpUpSize = 4.5f;
        private float _speed = 7f;
        private float _jumpForce = 13f;
        public float healthPoints
        {
            get 
            { 
                return _healthPoints; 
            }
            set 
            { 
                if (value > _maxHealthPoints) _healthPoints = _maxHealthPoints;
                else  _healthPoints = value;
            }
        }

        public float maxHealthPoints
        {
            get
            {
                return _maxHealthPoints;
            }
            set
            {
                _maxHealthPoints = value;
            }
        }

        public float damage
        {
            get
            {
                return _damage;
            }
            set
            {
                _damage = value;
            }
        }

        public float attackRange
        {
            get
            {
                return _attackRange;
            }
            set
            {
                _attackRange = value;
            }
        }

        public float armor
        {
            get
            {
                return _armor;
            }
            set
            {
                _armor = value;
            }
        }

        public float speedAttack
        {
            get
            {
                return _speedAttack;
            }
            set
            {
                _speedAttack = value;
            }
        }

        public float speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        public float jumpForce
        {
            get
            {
                return _jumpForce;
            }
            set
            {
                _jumpForce = value;
            }
        }

        public float jumpUpSize
        {
            get
            {
                return _jumpUpSize;
            }
            set
            {
                _jumpUpSize = value;
            }
        }
    }
}