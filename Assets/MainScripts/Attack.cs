using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField] private HeroMove heroPosition;
    [SerializeField] private InfoHero heroStats;
    [SerializeField] private LayerMask enemies;
    private EnemyStats enemyStats;
    private float timerAnimationOfAttack;
    private float timeFromAttack; 

    void Start()
    {
        heroPosition = GetComponent<HeroMove>();
        heroStats = GetComponent<InfoHero>();
    }

    public void OnSimpleAttack()
    {
        //if (Time.time > timeFromAttack + timerAnimationOfAttack)
        //{
        //state = States.SimpleAttack; // Анимация
        Collider2D[] damage = Physics2D.OverlapCircleAll(heroPosition.position, heroStats.attackRange, enemies);
        SimpleAttack(damage);
          //  timeFromAttack = Time.time;
        //}

         
        // Один из этих методов Time.fixedTime/Time.frameCount        
    }                                                                                                               


    public void SimpleAttack(Collider2D[] damage)
    {
        for(int i = 0; i < damage.Length; i++)
        {
            if (damage[i].CompareTag("Enemy"))
            {
                Hit(damage[i]);
            }
        }
    }
    
    private void Hit(Collider2D enemy)
    {
        enemyStats = enemy.GetComponent<EnemyStats>();
        enemyStats.healthPoints -= heroStats.damage;
        if (enemyStats.healthPoints <= 0) 
        {
            // Анимация смерти
            /*timeOfStartAnimDeath = Time.time;
            while (true)
            {
                if (timeOfStartAnimDeath < Time.time + timeOfEndAnimDeath)
                    break;
            }*/
            Destroy(enemy.gameObject); 

        }
    }
}
