using MainScripts.Move;
using MainScripts.Stats;
using UnityEngine;

namespace MainScripts.Attack
{
    public class HeroAttack : HeroMove
    {
        [SerializeField] private LayerMask _enemies;
        [SerializeField] private Transform _damagePoint;
        private Vector2 _damagePointPosition;

        public void OnSimpleAttack()
        {
            Collider2D[] enemy;

            _damagePointPosition.y = _damagePoint.position.y;
            _damagePointPosition.x = isFlip
                ? _damagePoint.position.x - 0.266f * 8f
                : _damagePoint.position.x;

            enemy = Physics2D.OverlapCircleAll(_damagePointPosition, attackRange, _enemies);
            SimpleAttack(enemy);
            // need timer to attack, use : Time.fixedTime/Time.frameCount
        }

        public void SimpleAttack(Collider2D[] enemy)
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i].CompareTag("Enemy"))
                    HitEnemy(enemy[i]);
                else if (enemy[i].CompareTag("Boss"))
                    HitBoss(enemy[i]);
            }
        }

        private void HitEnemy(Collider2D enemy)
        {
            EnemyStats enemyObj = enemy.gameObject.GetComponent<EnemyStats>();

            enemyObj.HealthPoint -= damage;
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

        private void HitBoss(Collider2D enemy)
        {
            /*BossStats enemyObj = enemy.gameObject.GetComponent<BossStats>();

            enemyObj.HealthPoint -= _heroStats.damage;
            if (enemyObj.HealthPoint <= 0)
            {
                *//*state = States.die;
            timeOfStartAnimDeath = Time.fixedTime;
            while (true)
            {
                if (timeOfStartAnimDeath < Time.time + timerTheAnimDeath)
                    break;
            }*//*
                Destroy(enemy.gameObject);
            }*/
        }
    }
}