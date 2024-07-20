using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongEnemySpawnController : MonoBehaviour
{
    public GameObject longEnemy;

    private Transform longEnemyTransform;

    // Start is called before the first frame update
    void Start()
    {
        SpawnInGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnInGame()
    {
        //spawn position setting
        longEnemyTransform = longEnemy.transform;
        Debug.Log("트랜스폼 가져오기");
        Debug.Log(NewDataManager.Instance.LongEnemyCount);
        int spawnLongEnemy = NewDataManager.Instance.LongEnemyCount;
        Debug.Log("spawnCount 설정");
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
        for (int i = 0; i < spawnLongEnemy; i++)
        {
            Instantiate(longEnemy, spawnPosition, Quaternion.identity);
        }
    }
}
