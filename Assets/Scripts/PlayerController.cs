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
    Animator animator;
    Rigidbody2D rigidbody2D;
    public static int bulletdir = 0;
    
    //체력관련
    public int maxHealth = 3;
    bool isDie = false;
    int health = 3;

    void Start() {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        int bulletdir = 0;

        //체력
        
        health = maxHealth;
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

        //체력 체크
           if (health == 0) {
           if(!isDie)
             Die ();

           return;
        }

    }


    void FixedUpdate() {
           if (health == 0)
               return;
    }


    void Die() {
        isDie = true;

        rigidbody2D.velocity = Vector2.zero;

        //사망 모션 애니메이션 구현 안됨
        //animator.Play("Die");

	  //떨어짐
      BoxCollider2D[] colls = gameObject.GetComponents<BoxCollider2D> ();
	  colls[0].enabled = false;
	  colls[1].enabled = false;

        //사망 튕김
	  Vector2 dieVelocity = new Vector2 (0,10f); 
      rigidbody2D.AddForce (dieVelocity, ForceMode2D.Impulse);

	  Invoke("RestartStage",2f);
    }

    void RestartStage () {
	  GameManager.RestartStage();
    }

/*
 몬스터와 접촉코드, 몬스터아 코드 제작 중이라 적용 안됨
    else if (other.gameObject.tag == "Creature" && !other.isTrigger && !(rigid.velocity.y < -10f)) {
	   Vector2 attackedVelocity = Vector2.zero;
	   if (other.gameObject.transform.position.x > transform.position.x)
	      attackedVelocity = new Vector2 (-2f, 7f);
	   else
		attackedVelocity = new Vector2 (-2f, 7f);

	   rigid.AddForce (attackedVelocity, ForceMode2D.Impulse);

	   health--;
    }
    if (other.gameObject.tag == "Bottom"){
        health = 0;
    }
*/

    void Print() {
	  Debug.Log(transform.position);
    }
}
