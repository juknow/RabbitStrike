using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this for TextMeshPro

public class LongEnemyNumberController : MonoBehaviour
{
    public TMP_Text infoText;

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
        NewDataManager.Instance.LongEnemyCount++;
        UpdateInfoText();

    }
    public void NumberMinus()
    {
        NewDataManager.Instance.LongEnemyCount--;
        UpdateInfoText();

    }
    void UpdateInfoText()
    {
        infoText.text = "Weapon range : <color=\"red\">Long</color>\n" +
                             "Move speed : <color=\"red\">Slow</color>\n" +
                             "Atk damage : <color=\"red\">" + NewDataManager.Instance.LongEnemyAttackDamage + "</color>\n" +
                             "HP : <color=\"red\">" + NewDataManager.Instance.LongEnemyHP + "</color>\n\n" +
                             "개수 : <color=\"green\">" + NewDataManager.Instance.LongEnemyCount + "</color>";
    }
}
