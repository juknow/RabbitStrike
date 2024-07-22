using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        switch (NewDataManager.Instance.StageLevel)
        {
            case (2):
                NewDataManager.Instance.BasicEnemyCount = 0;
                NewDataManager.Instance.ShortEnemyCount = 5;
                NewDataManager.Instance.LongEnemyCount = 0;


                break;
            case (3):
                NewDataManager.Instance.BasicEnemyCount = 0;
                NewDataManager.Instance.ShortEnemyCount = 0;
                NewDataManager.Instance.LongEnemyCount = 5;
                break;

            case (4):
                NewDataManager.Instance.BasicEnemyCount = 3;
                NewDataManager.Instance.ShortEnemyCount = 3;
                NewDataManager.Instance.LongEnemyCount = 2;
                break;
        }

    }

    public void GameReady()
    {
        //TypeCount


        Debug.Log("시작");
        SceneManager.LoadScene("Stage");
    }
}
