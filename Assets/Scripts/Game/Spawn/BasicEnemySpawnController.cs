using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemySpawnController : MonoBehaviour
{
    public GameObject basicEnemy;

    private Transform basicEnemyTransform;

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
        basicEnemyTransform = basicEnemy.transform;
        Debug.Log("트랜스폼 가져오기");
        Debug.Log(NewDataManager.Instance.ShortEnemyCount);
        int spawnBasicEnemy = NewDataManager.Instance.BasicEnemyCount;
        Debug.Log("spawnCount 설정");
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
        for (int i = 0; i < spawnBasicEnemy; i++)
        {
            Instantiate(basicEnemy, spawnPosition, Quaternion.identity);
        }
    }
}
