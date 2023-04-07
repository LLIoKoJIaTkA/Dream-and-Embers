using System;
using UnityEngine;

namespace MainScripts.GameObject
{
    public class EnemyObjects : MainObject/*, IEnemyObjects*/
    {
        /// <summary>
        /// Множитель который позволяет резать скорость enemy
        /// </summary>
        private float SpeedMultiplier = 0.05f;

        /// <summary>
        /// Область видимости enemy
        /// </summary>
        private float FieldOfView = 10f;
        
        /// <summary>
        /// Спройт enemy
        /// </summary>
        private SpriteRenderer _sprite;
        
        /// <summary>
        /// Маска чтобы, enemy при виде hero агрился, для этого нужно повесить Layer на hero
        /// </summary>
        [SerializeField] private LayerMask _heroMask;
        
        /// <summary>
        /// Массив векторов из 3-х точек(x,y,z) по которым, мониторит enemy.
        /// </summary>
        [SerializeField] private Vector3[] _positions;
        
        /// <summary>
        /// Тут мы задаем следует ли разворачивать enemy, когда он мониторит область
        /// </summary>
        [SerializeField] private int[] _rotations;
        
        /// <summary>
        /// Текущее положение enemy, по индексу
        /// </summary>
        private int _currentTarget = 0;
        
        /// <summary>
        /// Определяет видит ли enemy hero
        /// </summary>
        private bool _isHeroViewed = false;

        public virtual float speedMultiplier
        {
            get { return SpeedMultiplier; }
            set { SpeedMultiplier = value; }
        }

        public virtual float fieldOfView
        {
            get { return FieldOfView; }
            set { FieldOfView = value; }
        }

        public void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
        }

        public void Attack()
        {
            //ПОКА ЗАГЛУШКА
        }

        public void FixedUpdate()
        {
            _isHeroViewed = MoveByPointsAndMonitoring();
            if (_isHeroViewed)
            {
                RunToHeroAttack();
            }
        }

        public bool HeroFallIntoTheFieldOfView()
        {
            Collider2D[] filedOfViewEnemy = Physics2D.OverlapCircleAll(
                transform.position, 
                FieldOfView, 
                _heroMask
            );
            for (int i = 0; i< filedOfViewEnemy.Length; i++)
            {
                if(filedOfViewEnemy[i].CompareTag("Player"))
                {
                    return true;
                }
            }

            return false;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void RunToHeroAttack()
        {
            Debug.Log("HERO обнаружен");
        }

        public bool MoveByPointsAndMonitoring()
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                _positions[_currentTarget],
                speed * SpeedMultiplier
            );

            if (transform.position == _positions[_currentTarget])
            {
                if (_currentTarget < _positions.Length - 1)
                {
                    // TO DO Придумать нормальный разворот
                    _currentTarget++;
                }
                else
                {
                    _currentTarget = 0;
                }
            }

            if (HeroFallIntoTheFieldOfView())
            {
                return true;
            }

            return false;
        }

    }
}
