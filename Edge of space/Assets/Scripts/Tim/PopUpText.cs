using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textOutput;
    private int tutorialIndex;
    [SerializeField] [TextArea] private string tutorial_1, tutorial_2, tutorial_3, tutorial_4, tutorial_5, tutorial_6, tutorial_7, tutorial_8;

    // Start is called before the first frame update
    void Start()
    {
        textOutput.text = " ";
        textOutput.text = tutorial_1;
    }

    private void PopUp()
    {
        textOutput.text = tutorial_1;
    }
}
