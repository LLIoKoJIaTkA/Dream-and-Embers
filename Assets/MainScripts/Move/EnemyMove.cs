using System;
using MainScripts.Animation;
using MainScripts.Stats;
using Scenes._1_Scene___Forest.Scripts.Enemy.FireWizard;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MainScripts.Move
{
    public class EnemyMove : MonoBehaviour
    {
        /// <summary>
        /// Спройт enemy
        /// </summary>
        [SerializeField] protected SpriteRenderer _sprite;

        /// <summary>
        /// Текущее положение enemy, по индексу
        /// </summary>
        protected int _currentTarget = 0;
        
        /// <summary>
        /// Определяет видит ли enemy hero
        /// </summary>
        protected bool _isHeroViewed = false;

        /// <summary>
        /// Массив векторов из 3-х точек(x,y,z) по которым, мониторит enemy.
        /// </summary>
        [SerializeField] protected Vector3[] _positions;

        private EnemyStats _enemyStats;
        private MedievalWarriorAnimation _medievalWarriorAnimation;

        public void Start()
        {
            _enemyStats = GetComponent<EnemyStats>();
            _sprite = GetComponent<SpriteRenderer>();
            _medievalWarriorAnimation = GetComponent<MedievalWarriorAnimation>();
            _positions = new Vector3[_enemyStats.countPoints];

            if (_enemyStats.isWalkingTheDefaultPathByPoints)
            {
                Vector3 currentPosition = transform.position;
                _setPointByCurrentPosition(currentPosition);
            }
        }

        private void _setPointByCurrentPosition(Vector3 currentPosition)
        {
            for (int i = 0; i < _enemyStats.countPoints; i++)
            {
                _positions[i].Set(currentPosition.x + Random.Range(8, 20), currentPosition.y, currentPosition.z);
            }
        }
        
        public void FixedUpdate()
        {
            MoveByPoints();
        }

        public void HeroFallIntoTheFieldOfView()
        {
            Collider2D[] filedOfViewEnemy = Physics2D.OverlapCircleAll(
                transform.position, 
                _enemyStats.fieldOfView, 
                _enemyStats.heroMask
            );
            
            foreach (Collider2D element in filedOfViewEnemy)
            {
                if(element.CompareTag("Player"))
                {
                    _medievalWarriorAnimation.ChangeAnimation(MainAnimator.States.Run);
                }
            }

            _medievalWarriorAnimation.ChangeAnimation(MainAnimator.States.Walk);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void MoveByPoints()
        {
            _checkFieldOfViewOnWall();
            float finalSpeed = _enemyStats.speed * _enemyStats.speedMultiplier;
            transform.position = Vector3.MoveTowards(
                transform.position,
                _positions[_currentTarget],
                finalSpeed
            );

            if (transform.position == _positions[_currentTarget])
            {
                if (_currentTarget < _positions.Length - 1)
                {
                    _currentTarget++;
                    _sprite.flipX = _getFlipForMoveByPoints(transform.position, _positions[_currentTarget]);
                }
                else
                {
                    _currentTarget = 0;
                }
            }
            
        }
        
        /// <summary>
        /// Этот метод для поворота можно использовать только для ходьбы по точкам
        /// Тут все просто, если текущее положение меньше следующей точки, значит двигается вправо
        /// И нужно flipX поставить false, иначе true
        /// </summary>
        private bool _getFlipForMoveByPoints(Vector3 currentPosition, Vector3 nextPoint)
        {
            return !(currentPosition.x <= nextPoint.x - 6);//КОСТЫЛь)))
        }

        private void _checkFieldOfViewOnWall()
        {
            Collider2D[] filedOfViewWall = Physics2D.OverlapCircleAll(
                transform.position, 
                _enemyStats.fieldOfView, 
                _enemyStats.wallMask
            );
            
            foreach (Collider2D element in filedOfViewWall)
            {
                Debug.Log(element);
                if(element.CompareTag("Wall"))
                {
                    Debug.Log(element);
                }
            }
        }
        
    }
}
