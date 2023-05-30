using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int health;
    public PlayerController player;

    [SerializeField]
    private GameObject tower;
    void Start()  {

    }
    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Z)){

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
            Debug.Log("»ç¸Á");
        }
    }
    
    //³¶¶°·¯ÁöÃ¼Å©
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "player") ;
        //Ã¼·Â°¨¼Ò
        HealthDown();

        //³¶¶°·¯Áö¿¡ ¶³¾îÁö°í ´Ù½Ã Á¤À§Ä¡
        collision.attachedRigidbody.velocity = Vector2.zero;
        collision.transform.position = new Vector3(2, 2, -1);
    }

}
