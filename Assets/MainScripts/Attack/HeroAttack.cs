using MainScripts.Move;
using MainScripts.Stats;
using UnityEngine;

namespace MainScripts.Attack
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private HeroMove _heroMove; 
        [SerializeField] private HeroStats _heroStats;
        [SerializeField] private LayerMask _enemies;
        [SerializeField] private Transform _damagePoint;
        private Vector2 _damagePointPosition;

        void Start()
        {
            _heroStats = GetComponent<HeroStats>();
        }

        public void OnSimpleAttack()
        {
            Collider2D[] enemy;

            _damagePointPosition.y = _damagePoint.position.y;        
            _damagePointPosition.x = _heroMove.isFlip
                ? _damagePoint.position.x - 0.266f * 8f
                : _damagePoint.position.x;

            enemy = Physics2D.OverlapCircleAll(_damagePointPosition, _heroStats.attackRange, _enemies);
            SimpleAttack(enemy);
            // need timer to attack, use : Time.fixedTime/Time.frameCount
        }                                                                                                               


        public void SimpleAttack(Collider2D[] enemy)
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                Hit(enemy[i]);
            }
        }
    
        private void Hit(Collider2D enemy)
        {
            EnemyStats enemyObj = enemy.gameObject.GetComponent<EnemyStats>();

            enemyObj.HealthPoint -= _heroStats.damage;
            if (enemyObj.HealthPoint <= 0)
            {
                /*state = States.die;
            timeOfStartAnimDeath = Time.fixedTime;
            while (true)
            {
                if (timeOfStartAnimDeath < Time.time + timerTheAnimDeath)
                    break;
            }*/
                Destroy(enemy.gameObject);
            }               
        }
    }
}