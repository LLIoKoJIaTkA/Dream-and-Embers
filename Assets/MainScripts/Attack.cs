using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [SerializeField] private HeroMove _heroMove; 
    [SerializeField] private InfoHero _heroStats;
    [SerializeField] private LayerMask _enemies;
    private Vector2 _damagePointPosition;

    void Start()
    {
        _heroStats = GetComponent<InfoHero>();
    }

    public void OnSimpleAttack()
    {
        Collider2D[] enemy;

        _damagePointPosition.y = FindFirstObjectByType<Transform>().position.y;        
        _damagePointPosition.x = _heroMove.isFlip
            ? FindFirstObjectByType<Transform>().position.x - 0.266f * 8f
            : FindFirstObjectByType<Transform>().position.x;

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
        Enemy enemyObj = enemy.gameObject.GetComponent<Enemy>();

        enemyObj.healthPoints -= _heroStats.damage;
        if (enemyObj.healthPoints <= 0)
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