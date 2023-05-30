using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    
    [SerializeField]
    private GameObject tower;
    void Start()  {

    }
    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Z)){
            CreateTower();
        }
    }
    private void CreateTower(){
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        Instantiate(tower, mousePosition, Quaternion.identity);
    }
}
