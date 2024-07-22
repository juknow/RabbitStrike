using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this for TextMeshPro

public class LongNumberController : MonoBehaviour
{
    public TMP_Text infoText;

    // Start is called before the first frame update
    void Start()
    {
        NewDataManager.Instance.LongPlayerCount = 0;
        UpdateInfoText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NumberPlus()
    {
        if (NewDataManager.Instance.Cost >= 500)
        {
            NewDataManager.Instance.LongPlayerCount++;
            UpdateInfoText();
        }

    }
    public void NumberMinus()
    {
        if (NewDataManager.Instance.LongPlayerCount > 0)
        {
            NewDataManager.Instance.LongPlayerCount--;
            UpdateInfoText();
        }

    }
    void UpdateInfoText()
    {
        infoText.text = "Weapon range : <color=\"red\">Long</color>\n" +
                             "Move speed : <color=\"red\">slow</color>\n" +
                             "Atk damage : <color=\"red\">2</color>\n" +
                             "HP : <color=\"green\">10</color>\n" +
                             "Cost : <color=\"green\">300</color>\n\n" +
                             "개수 : <color=\"green\">" + NewDataManager.Instance.LongPlayerCount + "</color>";
    }
}
