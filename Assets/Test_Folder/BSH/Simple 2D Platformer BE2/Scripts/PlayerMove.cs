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

    //Update�� 1�ʿ� 60ȸ �ܹ����� �̺�Ʈó���� ���
    void Update()
    {
        //��ư�� ������ ���ߴ� ���ǵ�
        if (Input.GetButtonUp("Horizontal")){
            //normalized�� ����ũ�⸦ 1�θ��� ����(��������) ���ⱸ�Ҷ� ����� -1, 0, 1
            float stop_point = rigid.velocity.normalized.x * 1.2f;
            rigid.velocity = new Vector2(stop_point, rigid.velocity.y);
        }

        //sprite������ȯ
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

    // FixedUPdate�� 1�ʿ� 50ȸ���� ���ư��� .. Rigid���� ó���Ҷ� �ַ� �Ͽ�
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


        //////rigid.Velocity Used Velocity�� �������� ������////
        //rigid.velocity = new Vector2(maxSpeed * move, rigid.velocity.y);
    }
}
