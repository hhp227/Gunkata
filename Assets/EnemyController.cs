using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 3f;
    public float detectionRange = 5f;
    public GameObject bulletPrefab;
    public float attackRate = 2f;

    private Animator animator;
    private Transform player;
    private bool isMovingLeft = true;
    private float timeAfterAttack;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeAfterAttack = attackRate;
    }

    private void Update()
    {
        if (player == null)
            return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            Attack();
            ChangeDirection();
        }

        if (isMovingLeft)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
    }

    private void Attack()
    {
        timeAfterAttack += Time.deltaTime;

        if (timeAfterAttack >= attackRate)
        {
            timeAfterAttack = 0f;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }

    private void MoveLeft()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        animator.SetBool("isWalking", true);
    }

    private void MoveRight()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        animator.SetBool("isWalking", true);
    }

    private void ChangeDirection()
    {
        isMovingLeft = !isMovingLeft;
    }
}