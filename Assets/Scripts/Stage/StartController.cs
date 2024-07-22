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
        NewDataManager.Instance.LongEnemyCount = 3;
        NewDataManager.Instance.ShortEnemyCount = 3;
        NewDataManager.Instance.BasicEnemyCount = 3;
        NewDataManager.Instance.LongPlayerCount = 3;
        NewDataManager.Instance.ShortPlayerCount = 3;
        NewDataManager.Instance.BasicPlayerCount = 3;

        //StatSetting

        //BasicPlayer
        NewDataManager.Instance.BasicPlayerHP = 10.0f;
        NewDataManager.Instance.BasicPlayerMoveSpeed = 5.0f;
        NewDataManager.Instance.BasicPlayerAttackDamage = 1.0f;
        NewDataManager.Instance.BasicPlayerAttackCooldown = 1.0f;

        //ShortPlayer
        NewDataManager.Instance.ShortPlayerHP = 15.0f;
        NewDataManager.Instance.ShortPlayerMoveSpeed = 3.0f;
        NewDataManager.Instance.ShortPlayerAttackDamage = 1.0f;
        NewDataManager.Instance.ShortPlayerAttackCooldown = 1.0f;

        //LongPlayer

        NewDataManager.Instance.LongPlayerHP = 5.0f;
        NewDataManager.Instance.LongPlayerMoveSpeed = 2.0f;
        NewDataManager.Instance.LongPlayerAttackDamage = 1.0f;
        NewDataManager.Instance.LongPlayerAttackCooldown = 1.0f;

        //BasicEnemy
        NewDataManager.Instance.BasicEnemyHP = 10.0f;
        NewDataManager.Instance.BasicEnemyMoveSpeed = 5.0f;
        NewDataManager.Instance.BasicEnemyAttackDamage = 1.0f;
        NewDataManager.Instance.BasicEnemyAttackCooldown = 1.0f;

        //ShortEnemy
        NewDataManager.Instance.ShortEnemyHP = 15.0f;
        NewDataManager.Instance.ShortEnemyMoveSpeed = 3.0f;
        NewDataManager.Instance.ShortEnemyAttackDamage = 1.0f;
        NewDataManager.Instance.ShortEnemyAttackCooldown = 1.0f;

        //LongEnemy

        NewDataManager.Instance.LongEnemyHP = 5.0f;
        NewDataManager.Instance.LongEnemyMoveSpeed = 2.0f;
        NewDataManager.Instance.LongEnemyAttackDamage = 1.0f;
        NewDataManager.Instance.LongEnemyAttackCooldown = 1.0f;



        Debug.Log("시작");
        SceneManager.LoadScene("Game_Test");
    }
}
