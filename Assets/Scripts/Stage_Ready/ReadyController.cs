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
                NewDataManager.Instance.BasicEnemyCount = 4;
                NewDataManager.Instance.ShortEnemyCount = 4;
                NewDataManager.Instance.LongEnemyCount = 0;
                break;
            case (5):
                NewDataManager.Instance.BasicEnemyCount = 4;
                NewDataManager.Instance.ShortEnemyCount = 0;
                NewDataManager.Instance.LongEnemyCount = 4;
                break;
            case (6):
                NewDataManager.Instance.BasicEnemyCount = 0;
                NewDataManager.Instance.ShortEnemyCount = 5;
                NewDataManager.Instance.LongEnemyCount = 5;
                break;
            case (7):
                NewDataManager.Instance.BasicEnemyCount = 4;
                NewDataManager.Instance.ShortEnemyCount = 4;
                NewDataManager.Instance.LongEnemyCount = 4;
                break;
            case (8):
                NewDataManager.Instance.BasicEnemyCount = 8;
                NewDataManager.Instance.ShortEnemyCount = 4;
                NewDataManager.Instance.LongEnemyCount = 4;
                break;
            case (9):
                NewDataManager.Instance.BasicEnemyCount = 4;
                NewDataManager.Instance.ShortEnemyCount = 8;
                NewDataManager.Instance.LongEnemyCount = 4;
                break;
            case (10):
                NewDataManager.Instance.BasicEnemyCount = 4;
                NewDataManager.Instance.ShortEnemyCount = 4;
                NewDataManager.Instance.LongEnemyCount = 8;
                break;
            case (11):
                NewDataManager.Instance.BasicEnemyCount = 8;
                NewDataManager.Instance.ShortEnemyCount = 4;
                NewDataManager.Instance.LongEnemyCount = 6;
                break;
            case (12):
                NewDataManager.Instance.BasicEnemyCount = 8;
                NewDataManager.Instance.ShortEnemyCount = 6;
                NewDataManager.Instance.LongEnemyCount = 4;
                break;
            case (13):
                NewDataManager.Instance.BasicEnemyCount = 4;
                NewDataManager.Instance.ShortEnemyCount = 6;
                NewDataManager.Instance.LongEnemyCount = 6;
                break;
            case (14):
                NewDataManager.Instance.BasicEnemyCount = 10;
                NewDataManager.Instance.ShortEnemyCount = 5;
                NewDataManager.Instance.LongEnemyCount = 8;
                break;
            case (15):
                NewDataManager.Instance.BasicEnemyCount = 0;
                NewDataManager.Instance.ShortEnemyCount = 8;
                NewDataManager.Instance.LongEnemyCount = 10;
                break;
        }

    }

    void Update()
    {
        if (NewDataManager.Instance.StageLevel >= 6)
        {
            SceneManager.LoadScene("GameWin");
        }

    }

    public void GameReady()
    {
        //TypeCount


        Debug.Log("시작");
        SceneManager.LoadScene("Stage");
    }
}
