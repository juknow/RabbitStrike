using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this for TextMeshPro

public class ShortNumberController : MonoBehaviour
{
    public TMP_Text infoText;
    // Start is called before the first frame update
    void Start()
    {
        NewDataManager.Instance.ShortPlayerCount = 0;
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
            NewDataManager.Instance.ShortPlayerCount++;
            UpdateInfoText();
        }
    }
    public void NumberMinus()
    {
        if (NewDataManager.Instance.ShortPlayerCount > 0)
        {
            NewDataManager.Instance.ShortPlayerCount--;
            UpdateInfoText();
        }


    }
    void UpdateInfoText()
    {
        infoText.text = "Weapon range : <color=\"red\">Short</color>\n" +
                             "Move speed : <color=\"red\">Slow</color>\n" +
                             "Atk damage : <color=\"red\">" + NewDataManager.Instance.ShortPlayerAttackDamage + "</color>\n" +
                             "HP : <color=\"red\">" + NewDataManager.Instance.ShortPlayerHP + "</color>\n" +
                             "Cost : <color=\"red\">500</color>\n\n" +
                             "개수 : <color=\"green\">" + NewDataManager.Instance.ShortPlayerCount + "</color>";
    }
}
