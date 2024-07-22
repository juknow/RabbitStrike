using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this for TextMeshPro

public class CoinController : MonoBehaviour
{
    public TMP_Text coinText; // Reference to the TextMeshPro component
    // Start is called before the first frame update
    void Start()
    {
        NewDataManager.Instance.Cost = (NewDataManager.Instance.BasicEnemyCount * 300 + NewDataManager.Instance.ShortEnemyCount * 500 + NewDataManager.Instance.LongEnemyCount * 500);
        coinText.text = ": " + NewDataManager.Instance.Cost;
    }

    // Update is called once per frame
    void Update()
    {
        NewDataManager.Instance.Cost = (NewDataManager.Instance.BasicEnemyCount * 300 + NewDataManager.Instance.ShortEnemyCount * 500 + NewDataManager.Instance.LongEnemyCount * 500) - (NewDataManager.Instance.BasicPlayerCount * 300 + NewDataManager.Instance.ShortPlayerCount * 500 + NewDataManager.Instance.LongPlayerCount * 500);
        coinText.text = ": " + NewDataManager.Instance.Cost;

    }
}
