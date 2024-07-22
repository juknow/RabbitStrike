using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameStart()
    {
        //TypeCount



        Debug.Log("시작");
        SceneManager.LoadScene("Game_Test");
    }
    public void StageBack()
    {
        //TypeCount


        SceneManager.LoadScene("Stage_Ready");
    }
}
