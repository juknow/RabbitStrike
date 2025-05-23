using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this for TextMeshPro

public class BasicEnemyNumberController : MonoBehaviour
{
    public TMP_Text infoText;
    private int plus;
    private int minus;
    // Start is called before the first frame update
    void Start()
    {
        UpdateInfoText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NumberPlus()
    {
        NewDataManager.Instance.BasicEnemyCount++;
        UpdateInfoText();

    }
    public void NumberMinus()
    {
        NewDataManager.Instance.BasicEnemyCount--;
        UpdateInfoText();

    }

    void UpdateInfoText()
    {
        infoText.text = "Weapon range : <color=\"red\">Short</color>\n" +
                        "Move speed : <color=\"red\">Fast</color>\n" +
                        "Atk damage : <color=\"red\">" + NewDataManager.Instance.BasicEnemyAttackDamage + "</color>\n" +
                        "HP : <color=\"red\">" + NewDataManager.Instance.BasicEnemyHP + "</color>\n\n" +
                        "개수 : <color=\"green\">" + NewDataManager.Instance.BasicEnemyCount + "</color>";
    }
}
