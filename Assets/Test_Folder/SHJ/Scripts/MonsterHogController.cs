using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHogController : MonoBehaviour {
    private Rigidbody2D rigid;
    public int nextMove;
    public int hogspeed;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D collider;

    void Awake() {
       rigid = GetComponent<Rigidbody2D>();
       nextMove = 1;
       hogspeed = 1;
       spriteRenderer = GetComponent<SpriteRenderer>();
       collider = GetComponent<CapsuleCollider2D>();
        // Invoke("Think", 2);
    }

    private void FixedUpdate() {

        //이동
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y)* hogspeed;

        //낭떠러지 체크
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.2f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null) {
            nextMove *= -1;
            //Debug.Log("낭떠러지체크");

            //이미지 방향 뒤집기
            if(nextMove != 0)
            spriteRenderer.flipX = nextMove == -1;
            // CancelInvoke();
           //Invoke("Think", 2);
        }

    }

    //몬스터 움직임 좌우 랜덤
    /*
    void Think(){
        //nextMove = Random.Range(-1, 2);
        // Invoke("Think", 2);
    }
    */

    //몬스터 피격판정
    public void OnDamaged() {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        spriteRenderer.flipY = true;
        collider.enabled = false;
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        Invoke("DeActive", 5);
    }

    //몬스터 제거
    void DeActive() {
        gameObject.SetActive(false);
    }

}

