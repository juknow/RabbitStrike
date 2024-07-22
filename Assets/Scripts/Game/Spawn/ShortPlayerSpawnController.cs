using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortPlayerSpawnController : MonoBehaviour
{
    public GameObject shortPlayer;

    private Transform shortPlayerTransform;

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
        shortPlayerTransform = shortPlayer.transform;
        Debug.Log("트랜스폼 가져오기");
        int spawnShortPlayer = NewDataManager.Instance.ShortPlayerCount;
        Debug.Log("spawnCount 설정");
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
        for (int i = 0; i < spawnShortPlayer; i++)
        {
            Instantiate(shortPlayer, spawnPosition, Quaternion.identity);
        }
    }
}
