using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textOutput;
    private int tutorialIndex;
    [SerializeField] [TextArea] private string tutorial_1, tutorial_2, tutorial_3;

    // Start is called before the first frame update
    void Start()
    {
        textOutput.text = "fakka";
    }

    private void PopUp()
    {

    }
}
