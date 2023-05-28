using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

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

    private void CreateTower()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Vector3 pos = new Vector3(0, 4, 0);
            Instantiate(tower, pos, Quaternion.identity);
        }
    }
}
