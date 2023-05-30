using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int health;
    public PlayerController player;

    [SerializeField]
    private GameObject tower;
    // Start is called before the first frame update
    void Start()  {

        StartCoroutine(CreatetowerRoutine());
    
    }

    // Update is called once per frame
    void Update() {
        
    }

    IEnumerator CreatetowerRoutine()
    {
        while (true)
        {
            CreateTower();
            yield return new WaitForSeconds(1);
        }
    }

    private void CreateTower() {
        if (Input.GetKey(KeyCode.Z)) {
            Vector3 pos = new Vector3(0, 4, 0);
            Instantiate(tower, pos, Quaternion.identity);
        }
    }
    
    public void HealthDown() {
        if (health > 1)
            health--;
        else{
            player.OnDie();
            Debug.Log("사망");
        }
    }
    
    //낭떠러지체크
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "player") ;
        //체력감소
        HealthDown();

        //낭떠러지에 떨어지고 다시 정위치
        collision.attachedRigidbody.velocity = Vector2.zero;
        collision.transform.position = new Vector3(2, 2, -1);
    }

}
