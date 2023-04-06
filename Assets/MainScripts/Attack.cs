using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField] private HeroMove heroMove; 
    [SerializeField] private InfoHero heroStats;
    [SerializeField] private LayerMask enemies;
    private Vector2 damagePointPosition;

    void Start()
    {
        heroStats = GetComponent<InfoHero>();
    }

    public void OnSimpleAttack()
    {
        Collider2D[] enemy;
        damagePointPosition.y = FindFirstObjectByType<Transform>().position.y;
        damagePointPosition.x = FindFirstObjectByType<Transform>().position.x;
        if (!heroMove.isFlip)
        {
            Debug.Log(damagePointPosition + "isFlip: " + heroMove.isFlip);
            enemy = Physics2D.OverlapCircleAll(damagePointPosition, heroStats.attackRange, enemies);
        } 
        else
        {
            damagePointPosition.x -= 0.266f * 8f; //Dies from kringe :(
            Debug.Log(damagePointPosition + "isFlip: " + heroMove.isFlip);
            enemy = Physics2D.OverlapCircleAll(damagePointPosition, heroStats.attackRange, enemies);
        }
        SimpleAttack(enemy);
        // need timer to attack, use : Time.fixedTime/Time.frameCount
    }                                                                                                               


    public void SimpleAttack(Collider2D[] enemy)
    {
        for(int i = 0; i < enemy.Length; i++)
        {
            Debug.Log("egdsg");
            Hit(enemy[i]);            
        }
    }
    
    private void Hit(Collider2D enemy)
    {
        Enemy enemyObj = enemy.gameObject.GetComponent<Enemy>();
        enemyObj.healthPoints -= heroStats.damage;
        if(enemyObj.healthPoints <= 0)
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
