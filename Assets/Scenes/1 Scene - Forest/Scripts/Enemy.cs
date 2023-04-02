using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
    public float speed = 10.0f;
    private float speedMultiplier = 0.05f;
    [SerializeField] private const float fieldOfView = 10f;
    [SerializeField] private LayerMask heroMask;

    public Vector3[] positions;
    public int[] rotations = { 1, 0, 1 };
    private int currentTarget = 0;
    private SpriteRenderer sprite;
    private bool isHeroViewed = false;
    private GameObject hero;

    private Animator animator;
    private string currentAnimation;

    public void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    public void FixedUpdate()
    {
        if(!isHeroViewed)
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed * speedMultiplier);

            if (transform.position == positions[currentTarget])
            {
                if (currentTarget < positions.Length - 1)
                {
                    //sprite.flipX = rotations[currentTarget] == 1 ? true : false;
                    currentTarget++;
                }
                else
                {
                    currentTarget = 0;
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, hero.transform.position, speed * speedMultiplier);
        }
    }

    public void Update()
    {
        if (!isHeroViewed)
        {
            heroInFieldOfView();
        }
    }

    public void heroInFieldOfView()
    {
        Collider2D[] filedOfViewEnemy = Physics2D.OverlapCircleAll(transform.position, fieldOfView, heroMask);
        for(int i = 0; i< filedOfViewEnemy.Length; i++)
        {
            if(filedOfViewEnemy[i].CompareTag("Player"))
            {
                speedMultiplier = 0.1f;
                changeAnimation("Run");
                isHeroViewed = true;
            }
        }

    }

    private void changeAnimation(string animation)
    {
        if (currentAnimation == animation) return;

        animator.Play(animation);
        currentAnimation = animation;
    }

}
