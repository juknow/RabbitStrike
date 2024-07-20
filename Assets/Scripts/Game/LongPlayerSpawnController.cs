using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongPlayerSpawnController : MonoBehaviour
{
    public GameObject longPlayer;

    private Transform longPlayerTransform;

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
        longPlayerTransform = longPlayer.transform;
        Debug.Log("트랜스폼 가져오기");
        Debug.Log(NewDataManager.Instance.LongPlayerCount);
        int spawnPlayerEnemy = NewDataManager.Instance.LongPlayerCount;
        Debug.Log("spawnCount 설정");
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
        for (int i = 0; i < spawnPlayerEnemy; i++)
        {
            Instantiate(longPlayer, spawnPosition, Quaternion.identity);
        }
    }
}
