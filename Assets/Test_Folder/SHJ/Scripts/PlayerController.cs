//
//  PlayerController.cs
//  Gunkata
//
//  Created by hhp227 on 2023/05/05.
//  Copyright © 2023 ?????. All rights reserved.
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public GameManager gameManager;
    Animator animator;
    Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;

    public static int bulletdir = 0;


    void Start() {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        int bulletdir = 0;
    }

    //주석테스트
    void Update() {
        animator.SetBool("run", false);
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(Vector2.right * 0.005f);
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("run", true);
            bulletdir = 0;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(Vector2.left * 0.005f);
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("run", true);
            bulletdir = 1;

        }
        if (Input.GetKey(KeyCode.Space)) {
            rigidbody2D.AddForce(Vector2.up * 4);
            rigidbody2D.gravityScale = 2;
        }
    }

        //피격판정
        void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.tag == "Enemy")
            {
                //공격
                if (rigidbody2D.velocity.y < 0 && transform.position.y > collision.transform.position.y)
                {
                    Debug.Log("player attack!");
                    OnAttack(collision.transform);
                }else 
                //피격
                    Debug.Log("player hit!");
                    OnDamaged(collision.transform.position);
            }
        }

        //몬스터 공격판정
        void OnAttack(Transform enemy) {
            MonsterHogController monsterHogController = enemy.GetComponent<MonsterHogController>();
            monsterHogController.OnDamaged();
        }
        //피격 판정
        void OnDamaged(Vector2 targetPos) {
        //체력 하락
            gameManager.HealthDown();

            //피격시 데미지 레이어로 변경
            gameObject.layer = 11;

            //피격시 색상 변경
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);

            //피격시 튕겨나감
            int dir = transform.position.x - targetPos.x > 0 ? 1 : -1;
            rigidbody2D.AddForce(new Vector2(dir, 1) * 2, ForceMode2D.Impulse);
            spriteRenderer.flipY = true;
            Invoke("OffDamaged", 3);
        }
        
        //피격 후 정상화
        void OffDamaged() {
            gameObject.layer = 10;
            spriteRenderer.color = new Color(1, 1, 1, 1);
            spriteRenderer.flipY = false;
        }

        //사망
        public void OnDie() {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        spriteRenderer.flipY = true;
        GetComponent<Collider>().enabled = false;
        rigidbody2D.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
    }
}
