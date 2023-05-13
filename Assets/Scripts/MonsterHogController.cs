using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHogController : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed = 5.0f; // ���� �̵� �ӵ�
    public float leftBound = -5.0f; // ���Ͱ� �̵��ϴ� �ּ� x ��ǥ
    public float rightBound = 5.0f; // ���Ͱ� �̵��ϴ� �ִ� x ��ǥ

    private bool isGrounded = false;
    private float direction = 1f;

    public Transform groundCheck;
    public LayerMask groundLayer;

    void Start() {
    }

    // Update is called once per frame
    void Update() {
        // ���͸� �̵���Ŵ
        Vector3 movement = new Vector3(direction * speed * Time.deltaTime, 0, 0);
        transform.position += movement;

        if (transform.position.x >= rightBound || transform.position.x <= leftBound) {
            direction *= -1;
            transform.localScale = new Vector3(direction, 1, 1); // ������ �̹����� �ݴ�� ������
        }
    }

    private void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if (!isGrounded) {
            direction = -direction;
            transform.localScale = new Vector3(direction, 1f, 1f);
        }

        // ���� �������� �̵��մϴ�.
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }
}
