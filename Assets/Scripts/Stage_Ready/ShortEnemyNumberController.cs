using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this for TextMeshPro

public class ShortEnemyNumberController : MonoBehaviour
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
        NewDataManager.Instance.ShortEnemyCount++;
        UpdateInfoText();

    }
    public void NumberMinus()
    {
        NewDataManager.Instance.ShortEnemyCount--;
        UpdateInfoText();

    }
    void UpdateInfoText()
    {
        infoText.text = "Weapon range : <color=\"red\">Short</color>\n" +
                                "Move speed : <color=\"red\">fast</color>\n" +
                                "Atk damage : <color=\"red\">3</color>\n" +
                                "HP : <color=\"green\">15</color>\n\n" +
                                "개수 : <color=\"green\">" + NewDataManager.Instance.ShortEnemyCount + "</color>";
    }
}
