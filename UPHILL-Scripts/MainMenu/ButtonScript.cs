using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _startButton;

    [SerializeField]
    private TextMeshProUGUI _aboutButton;

    [SerializeField]
    private TextMeshProUGUI _creditsButton;

    [SerializeField]
    private TextMeshProUGUI _escapeButton;


    public void HideAllButtons()
    {
        _startButton.text = "";
        _aboutButton.text = "";
        _creditsButton.text = "";
        _escapeButton.text = "";
    }


    public void HideAllShowEscape()
    {
        _startButton.text = "";
        _aboutButton.text = "";
        _creditsButton.text = "";
        _escapeButton.text = "ESCAPE";
    }


    public void ShowAllHideEscape()
    {
        _startButton.text = "START";
        _aboutButton.text = "ABOUT";
        _creditsButton.text = "CREDITS";
        _escapeButton.text = "";
    }
}
