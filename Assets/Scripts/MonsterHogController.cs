using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHogController : MonoBehaviour {
    private Rigidbody2D rigid;
    public int nextMove;

    void Awake() {
       rigid = GetComponent<Rigidbody2D>();
        nextMove = 1;
      // Invoke("Think", 2);
    }

    private void FixedUpdate() {

        //�̵�
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        //�������� üũ
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.2f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider == null) {
            nextMove *= -1;
            Debug.Log("��������üũ");
           
            // CancelInvoke();
           //Invoke("Think", 2);
        }

    }

    void Think(){
        //���� ������ �¿� ����
        //nextMove = Random.Range(-1, 2);
        // Invoke("Think", 2);
    }
}

