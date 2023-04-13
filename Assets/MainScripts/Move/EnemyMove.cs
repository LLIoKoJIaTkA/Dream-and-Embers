using System.Collections;
using MainScripts.Animation;
using MainScripts.Stats;
using Scenes._1_Scene___Forest.Scripts.Enemy.FireWizard;
using UnityEngine;

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

            if (_enemyStats.isWalkingTheDefaultPathByPoints)
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
            MoveByPoints();
        }

        public void HeroFallIntoTheFieldOfView()
        {
            Collider2D[] filedOfViewEnemy = Physics2D.OverlapCircleAll(
                transform.position, 
                _enemyStats.fieldOfView, 
                _enemyStats.heroMask
            );
            
            for (int i = 0; i< filedOfViewEnemy.Length; i++)
            {
                if(filedOfViewEnemy[i].CompareTag("Player"))
                {
                    _medievalWarriorAnimation.ChangeAnimation(MainAnimator.States.Run);
                }
            }

            _medievalWarriorAnimation.ChangeAnimation(MainAnimator.States.Walk);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void MoveByPoints()
        {
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
                    if (_enemyStats.isStayInPoint)
                    {
                        //TO DO придумать логику остановки на точках
                    }
                    
                    _sprite.flipX = _getFlipForMoveByPoints(transform.position, _positions[_currentTarget + 1]);
                    _currentTarget++;
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
            return !(currentPosition.x <= nextPoint.x);
        }

    }
}
