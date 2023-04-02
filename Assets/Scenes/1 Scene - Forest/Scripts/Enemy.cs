using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Enemy : MonoBehaviour
{
    private float speedMultiplier = 0.05f;
    [SerializeField] private const float fieldOfView = 10f;
    [SerializeField] private LayerMask heroMask;

    public float speed = 10.0f;
    public Vector3[] positions;
    public int[] rotations = { 1, 0, 1, 0, 0 };
    private int currentTarget;
    private SpriteRenderer sprite;
    private bool isHeroViewed = false;

    private GameObject hero = GameObject.FindGameObjectWithTag("Player");

    private Animator animator;
    private string currentAnimation;

    public void Start()
    {
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
                    if (rotations[currentTarget] == 1)
                    {
                        sprite.flipX = true;
                    }
                    else if (rotations[currentTarget] == 0)
                    {
                        sprite.flipX = false;
                    }
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
        heroInFieldOfView();
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
