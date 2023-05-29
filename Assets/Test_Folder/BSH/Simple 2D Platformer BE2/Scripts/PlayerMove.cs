using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float maxSpeed;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    //Update는 1초에 60회 단발적인 이벤트처리시 사용
    void Update()
    {
        //버튼을 땠을때 멈추는 스피드
        if (Input.GetButtonUp("Horizontal")){
            //normalized는 벡터크기를 1로만든 상태(단위벡터) 방향구할때 사용함 -1, 0, 1
            float stop_point = rigid.velocity.normalized.x * 1.2f;
            rigid.velocity = new Vector2(stop_point, rigid.velocity.y);
        }

        //sprite방향전환
        if (Input.GetButton("Horizontal")) {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }

        //walk Animation
        if (Mathf.Abs(rigid.velocity.x) < 0.3){
            anim.SetBool("isWalking", false);
        }
        else {
            anim.SetBool("isWalking", true);
        }
    }

    // FixedUPdate는 1초에 50회정도 돌아간다 .. Rigid관련 처리할때 주로 하용
    void FixedUpdate()
    {
        //move Controll
        float move = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * move, ForceMode2D.Impulse);
        //max Speed
        if (rigid.velocity.x > maxSpeed){
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        }else if (rigid.velocity.x < maxSpeed * (-1)){
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        }


        //////rigid.Velocity Used Velocity는 지속적인 움직임////
        //rigid.velocity = new Vector2(maxSpeed * move, rigid.velocity.y);
    }
}
