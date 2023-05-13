using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHogController : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed = 5.0f; // 몬스터 이동 속도
    public float leftBound = -5.0f; // 몬스터가 이동하는 최소 x 좌표
    public float rightBound = 5.0f; // 몬스터가 이동하는 최대 x 좌표

    private bool isGrounded = false;
    private float direction = 1f;

    public Transform groundCheck;
    public LayerMask groundLayer;

    void Start() {
    }

    // Update is called once per frame
    void Update() {
        // 몬스터를 이동시킴
        Vector3 movement = new Vector3(direction * speed * Time.deltaTime, 0, 0);
        transform.position += movement;

        if (transform.position.x >= rightBound || transform.position.x <= leftBound) {
            direction *= -1;
            transform.localScale = new Vector3(direction, 1, 1); // 몬스터의 이미지를 반대로 뒤집음
        }
    }

    private void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (!isGrounded) {
            direction = -direction;
            transform.localScale = new Vector3(direction, 1f, 1f);
        }

        // 현재 방향으로 이동합니다.
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }
}
