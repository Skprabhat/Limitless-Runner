using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Player : MonoBehaviour
{
    [Header("Player Values")]
    public float speed;
    public float AttackRadius;
    public float JumpForce;
    public float Radius;
    public Rigidbody2D rb;
    public Animator anim;
    [Space]
    public Transform Groundcheck;
    public Transform AttackPoint;
    [Space]
    public LayerMask WhatisGround;
    public LayerMask EnemyLayers;
    
    public float score;
    int Jumpcount;
    float timer;
    float SpeedIncreaseTime=7f;
    bool isGrounded;
    bool isAttacking;
    public bool IsGameOver;
    public bool SpeedIncreaseText;
    // Use this for initialization
    void Start()
    {
        score = 0;
        Time.timeScale = 1;
        timer = SpeedIncreaseTime;
        IsGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
            
        else
        {
            speed += 0.5f;
            SpeedIncreaseText = true;
            timer = SpeedIncreaseTime;
        }
        if(Input.GetKeyDown(KeyCode.Space)&&isAttacking==false)
        {
            Attack();
            isAttacking = true;
        }

        isGrounded = Physics2D.OverlapCircle(Groundcheck.position, Radius, WhatisGround);
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (Input.GetMouseButtonDown(0) && isGrounded == true && !EventSystem.current.IsPointerOverGameObject())
        {
            Jump();
           
        }
       
    }

    void Jump()
    {
        anim.SetTrigger("Jump");
        rb.velocity = new Vector2(rb.velocity.x, JumpForce);
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
        Collider2D[] hit=Physics2D.OverlapCircleAll(AttackPoint.position, AttackRadius, EnemyLayers);

        foreach (var enemy in hit)
        {
            Debug.Log("HIt");
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRadius);
    }
    public void DisableAttack()
    {
        isAttacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
            score += 3;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("GameOver"))
        {
            Time.timeScale = 0;
            IsGameOver = true;
        }
    }
}
