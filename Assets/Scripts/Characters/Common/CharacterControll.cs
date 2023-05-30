using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public float maxSpeed;
    public float jumpPower;



    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        //Stop Speed
        if (Input.GetButtonUp("Horizontal")) {
            float stopSpeed = 1.2f;
            float stopArrow = rigid.velocity.normalized.x * stopSpeed;
            rigid.velocity = new Vector2(stopArrow, rigid.velocity.y);
        }

        //Character Sprite Horizon Change
        if (Input.GetButton("Horizontal")){
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //Running animation
        if(Mathf.Abs(rigid.velocity.x) < 0.3){
            anim.SetBool("isRunning", false);
        }else {
            anim.SetBool("isRunning", true);
        }

        //Jump
        if (Input.GetButtonDown("Jump")) {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        //Movement
        float getKeyArrow = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * getKeyArrow, ForceMode2D.Impulse);

        //Limit Speed
        if (rigid.velocity.x > maxSpeed) {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        } else if (rigid.velocity.x < maxSpeed * (-1)) {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }

    }
}
