using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerSpawnController : MonoBehaviour
{
    public GameObject basicPlayer;

    private Transform basicPlayerTransform;

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
        basicPlayerTransform = basicPlayer.transform;
        Debug.Log("트랜스폼 가져오기");
        Debug.Log(NewDataManager.Instance.ShortPlayerCount);
        int spawnBasicPlayer = NewDataManager.Instance.BasicPlayerCount;
        Debug.Log("spawnCount 설정");
        Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y);
        for (int i = 0; i < spawnBasicPlayer; i++)
        {
            Instantiate(basicPlayer, spawnPosition, Quaternion.identity);
        }
    }
}
