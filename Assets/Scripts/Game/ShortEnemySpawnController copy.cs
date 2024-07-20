using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortEnemySpawnController : MonoBehaviour
{
    public GameObject shortEnemy;
    public GameObject basicEnemy;

    private Transform shortEnemyTransform;
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
        shortEnemyTransform = shortEnemy.transform;
        basicEnemyTransform = basicEnemy.transform;
        Debug.Log("트랜스폼 가져오기");
        Debug.Log(NewDataManager.Instance.ShortEnemyCount);
        int spawnShortEnemy = NewDataManager.Instance.ShortEnemyCount;
        int spawnBasicEnemy = NewDataManager.Instance.BasicEnemyCount;
        Debug.Log("spawnCount 설정");
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
        for (int i = 0; i < spawnShortEnemy; i++)
        {
            Instantiate(shortEnemy, spawnPosition, Quaternion.identity);
        }
        for (int i = 0; i < spawnBasicEnemy; i++)
        {
            Instantiate(basicEnemy, spawnPosition, Quaternion.identity);
        }
    }
}
