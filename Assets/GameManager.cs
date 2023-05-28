using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
