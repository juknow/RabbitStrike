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

        //StatSetting

        //BasicPlayer
        NewDataManager.Instance.BasicPlayerHP = 15.0f;
        NewDataManager.Instance.BasicPlayerMoveSpeed = 6.0f;
        NewDataManager.Instance.BasicPlayerAttackDamage = 3.0f;
        NewDataManager.Instance.BasicPlayerAttackCooldown = 1.0f;

        //ShortPlayer
        NewDataManager.Instance.ShortPlayerHP = 15.0f;
        NewDataManager.Instance.ShortPlayerMoveSpeed = 2.0f;
        NewDataManager.Instance.ShortPlayerAttackDamage = 5.0f;
        NewDataManager.Instance.ShortPlayerAttackCooldown = 1.0f;

        //LongPlayer

        NewDataManager.Instance.LongPlayerHP = 10.0f;
        NewDataManager.Instance.LongPlayerMoveSpeed = 2.0f;
        NewDataManager.Instance.LongPlayerAttackDamage = 2.0f;
        NewDataManager.Instance.LongPlayerAttackCooldown = 1.0f;

        //BasicEnemy
        NewDataManager.Instance.BasicEnemyHP = 15.0f;
        NewDataManager.Instance.BasicEnemyMoveSpeed = 6.0f;
        NewDataManager.Instance.BasicEnemyAttackDamage = 3.0f;
        NewDataManager.Instance.BasicEnemyAttackCooldown = 1.0f;

        //ShortEnemy
        NewDataManager.Instance.ShortEnemyHP = 15.0f;
        NewDataManager.Instance.ShortEnemyMoveSpeed = 2.0f;
        NewDataManager.Instance.ShortEnemyAttackDamage = 5.0f;
        NewDataManager.Instance.ShortEnemyAttackCooldown = 1.0f;

        //LongEnemy

        NewDataManager.Instance.LongEnemyHP = 10.0f;
        NewDataManager.Instance.LongEnemyMoveSpeed = 2.0f;
        NewDataManager.Instance.LongEnemyAttackDamage = 2.0f;
        NewDataManager.Instance.LongEnemyAttackCooldown = 1.0f;



        Debug.Log("시작");
        SceneManager.LoadScene("Game_Test");
    }
}
