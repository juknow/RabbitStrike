using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this for TextMeshPro

public class BasicNumberController : MonoBehaviour
{
    public TMP_Text infoText;
    // Start is called before the first frame update
    void Start()
    {
        NewDataManager.Instance.BasicPlayerCount = 0;
        UpdateInfoText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NumberPlus()
    {
        if (NewDataManager.Instance.Cost >= 300)
        {
            NewDataManager.Instance.BasicPlayerCount++;
            UpdateInfoText();
        }

    }
    public void NumberMinus()
    {
        if (NewDataManager.Instance.BasicPlayerCount > 0)
        {
            NewDataManager.Instance.BasicPlayerCount--;
            UpdateInfoText();
        }

    }

    void UpdateInfoText()
    {
        infoText.text = "Weapon range : <color=\"red\">Short</color>\n" +
                        "Move speed : <color=\"red\">Fast</color>\n" +
                        "Atk damage : <color=\"red\">" + NewDataManager.Instance.BasicPlayerAttackDamage + "</color>\n" +
                        "HP : <color=\"red\">" + NewDataManager.Instance.BasicPlayerHP + "</color>\n" +
                        "Cost : <color=\"red\">300</color>\n\n" +
                        "개수 : <color=\"green\">" + NewDataManager.Instance.BasicPlayerCount + "</color>";
    }
}
