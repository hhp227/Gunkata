using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public float speed;
    void Start() {

        //인자값 (function, int)
        Invoke("DestroyBullet", 2);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void DestroyBullet() {
        Destroy(gameObject);
    }
}
