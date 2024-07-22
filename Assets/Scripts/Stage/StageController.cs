using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Add this for TextMeshPro

public class StageController : MonoBehaviour
{
    public TMP_Text stageText; // Reference to the TextMeshPro component
    // Start is called before the first frame update
    void Start()
    {
        stageText.text = "[ STAGE  - " + NewDataManager.Instance.StageLevel + " ]";

    }

    // Update is called once per frame
    void Update()
    {

    }
}
