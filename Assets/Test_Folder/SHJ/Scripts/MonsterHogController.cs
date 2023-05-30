using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHogController : MonoBehaviour {
    private Rigidbody2D rigid;
    public int nextMove;
<<<<<<< HEAD:Assets/Scripts/MonsterHogController.cs
    public int speed;
=======
    public int hogspeed;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D collider;
>>>>>>> 8bb20a4a7819e97760d51073cbd941b12702cfca:Assets/Test_Folder/SHJ/Scripts/MonsterHogController.cs

    void Awake() {
       rigid = GetComponent<Rigidbody2D>();
       nextMove = 1;
       hogspeed = 1;
       spriteRenderer = GetComponent<SpriteRenderer>();
       collider = GetComponent<CapsuleCollider2D>();
        // Invoke("Think", 2);
    }

    private void FixedUpdate() {

        //�̵�
<<<<<<< HEAD:Assets/Scripts/MonsterHogController.cs
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y) * 2;
=======
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y)* hogspeed;
>>>>>>> 8bb20a4a7819e97760d51073cbd941b12702cfca:Assets/Test_Folder/SHJ/Scripts/MonsterHogController.cs

        //�������� üũ
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.2f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null) {
            nextMove *= -1;
            //Debug.Log("��������üũ");

            //�̹��� ���� ������
            if(nextMove != 0)
            spriteRenderer.flipX = nextMove == -1;
            // CancelInvoke();
           //Invoke("Think", 2);
        }

    }

    //���� ������ �¿� ����
    /*
    void Think(){
        //nextMove = Random.Range(-1, 2);
        // Invoke("Think", 2);
    }
    */

    //���� �ǰ�����
    public void OnDamaged() {
        spriteRenderer.color = new Color(1, 1, 1, 0.4f);
        spriteRenderer.flipY = true;
        collider.enabled = false;
        rigid.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        Invoke("DeActive", 5);
    }

    //���� ����
    void DeActive() {
        gameObject.SetActive(false);
    }

}

