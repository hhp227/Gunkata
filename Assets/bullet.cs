using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    // Start is called before the first frame update

    public float speed;

    void Start() {
        Invoke("DestroyBullet", 2);
    }

    // Update is called once per frame
    void Update() {
	  if(transform.rotation.y == 0){
        transform.Translate(transform.right * speed * Time.deltaTime); //총알방향 오른쪽
        }
        else{
	  transform.Translate(transform.right * -1 * speed * Time.deltaTime); //총알방향 왼쪽
        }
        }
    void DestroyBullet() {
        Destroy(gameObject);
    }
}
