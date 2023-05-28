using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class GameManager : MonoBehaviour
{

    public static void RestartStage () {

	  //게임정지
	  Time.timeScale = 0f;

	  //재시작인데 코드 미구현 상태임
      //SceneManager.LoadScene (stageLevel, LoadSceneMode.single);
    }

/*
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
*/
=======
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
>>>>>>> origin/#6-tower
}
