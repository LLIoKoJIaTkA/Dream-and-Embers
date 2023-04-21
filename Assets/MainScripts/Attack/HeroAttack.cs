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
        private float startAttackAnimation;
        private float timeAttackAnimation = 0.80f;

        private void FixedUpdate()
        {
            if (isAttack)
                CheckEndAttack();
        }

        private void CheckEndAttack() 
        {
            if (Time.time >= startAttackAnimation + timeAttackAnimation)
                isAttack = false;
        }

        public void OnSimpleAttack()
        {
            if (!isAttack) { 
                startAttackAnimation = Time.time;
                isAttack = true;

                _damagePointPosition.y = _damagePoint.position.y;
                _damagePointPosition.x = isFlip
                    ? _damagePoint.position.x - 0.266f * 8f
                    : _damagePoint.position.x;

                Collider2D[] enemy = Physics2D.OverlapCircleAll(_damagePointPosition, attackRange, _enemies);
                SimpleAttack(enemy);
                // need timer to attack, use : Time.fixedTime/Time.frameCount                
            }
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

            enemyObj.healthPoint -= damage;
            if (enemyObj.healthPoint <= 0)
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