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

    void Start() {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    //주석테스트
    void Update() {
        animator.SetBool("run", false);
        if (Input.GetKey(KeyCode.RightArrow)) {
            transform.Translate(Vector2.right * 0.005f);
            transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool("run", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(Vector2.left * 0.005f);
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("run", true);
        }
        if (Input.GetKey(KeyCode.Space)) {
            rigidbody2D.AddForce(Vector2.up * 4);
            rigidbody2D.gravityScale = 2;
        }
    }
}
