using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public float coolTime;
    private float curTime;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            //Realtime Object Create
            Instantiate(bullet, pos.position, transform.rotation);
        }

    }
}
