using MainScripts.Stats;
using UnityEngine;

namespace MainScripts.Move
{
    public sealed class EnemyObjects : MonoBehaviour
    {
        /// <summary>
        /// Спройт enemy
        /// </summary>
        private SpriteRenderer _sprite;

        /// <summary>
        /// Текущее положение enemy, по индексу
        /// </summary>
        private int _currentTarget = 0;
        
        /// <summary>
        /// Определяет видит ли enemy hero
        /// </summary>
        private bool _isHeroViewed = false;

        private EnemyStats _enemyStats;
        
        /// <summary>
        /// Массив векторов из 3-х точек(x,y,z) по которым, мониторит enemy.
        /// </summary>
        [SerializeField] private Vector3[] _positions;
        
        public void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
        }

        public void FixedUpdate()
        {
            MoveByPointsAndMonitoring();
        }

        public bool HeroFallIntoTheFieldOfView()
        {
            Collider2D[] filedOfViewEnemy = Physics2D.OverlapCircleAll(
                transform.position, 
                _enemyStats.FieldOfView, 
                _enemyStats._heroMask
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

        public void MoveByPointsAndMonitoring()
        {
            var finalSpeed = _enemyStats.Speed * _enemyStats.SpeedMultiplier;
            transform.position = Vector3.MoveTowards(
                transform.position,
                _positions[_currentTarget],
                finalSpeed
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
        }

    }
}
