using MainScripts.Stats;
using UnityEngine;

namespace MainScripts.Move
{
    public class EnemyMove : EnemyStats
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

        /// <summary>
        /// Массив векторов из 3-х точек(x,y,z) по которым, мониторит enemy.
        /// </summary>
        [SerializeField] private Vector3[] _positions;
        
        public void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();
            if (isWalkingTheDefaultPathByPoints)
            {
                Vector3 currentPosition = transform.position;
                _setPointByCurrentPosition(currentPosition);
            }
        }

        private void _setPointByCurrentPosition(Vector3 currentPosition)
        {
            _positions[0] = currentPosition;
            Vector3 leftPointByCenter, rightPointByCenter;
            leftPointByCenter.x = currentPosition.x - 10;
            leftPointByCenter.y = currentPosition.y;
            leftPointByCenter.z = currentPosition.z;
            rightPointByCenter.x = currentPosition.x + 10;
            rightPointByCenter.y = currentPosition.y;
            rightPointByCenter.z = currentPosition.z;
            _positions[1] = leftPointByCenter;
            _positions[2] = rightPointByCenter;
        }
        
        public void FixedUpdate()
        {
            MoveByPointsAndMonitoring();
        }

        public bool HeroFallIntoTheFieldOfView()
        {
            Collider2D[] filedOfViewEnemy = Physics2D.OverlapCircleAll(
                transform.position, 
                fieldOfView, 
                heroMask
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

        private void MoveByPointsAndMonitoring()
        {
            var finalSpeed = speed * speedMultiplier;
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
