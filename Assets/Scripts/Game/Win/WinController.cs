using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        // Check for objects with Enemy tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // Determine the winner based on the presence of Player and Enemy objects
        if (players.Length == 0 && enemies.Length == 0)
        {
            Debug.Log("Draw! No Players or Enemies left.");
            SceneManager.LoadScene("Stage");
        }
        else if (players.Length == 0)
        {
            Debug.Log("Enemy Wins! No Players left.");
            SceneManager.LoadScene("GameOver_Test");
        }
        else if (enemies.Length == 0)
        {
            Debug.Log("Player Wins! No Enemies left.");
            SceneManager.LoadScene("Stage_Ready");
            NewDataManager.Instance.StageLevel++;
            if (NewDataManager.Instance.SavedStageLevel < NewDataManager.Instance.StageLevel)
            {
                NewDataManager.Instance.SavedStageLevel = NewDataManager.Instance.StageLevel;
            }
        }

    }
}
