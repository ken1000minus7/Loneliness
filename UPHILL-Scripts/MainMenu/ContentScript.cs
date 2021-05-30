using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ContentScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;


    public void ShowCredits()
    {
        _text.text = "Game development: Armaan Badhan\n" +
            "Pixel Art, story: Rijul Singla\n" +
            "Music used: 'VGMA-Challenge-July-13th'\n" +
            "            'Ludun-Dare-28 Track 3'\n" +
            "            http://abstractionmusic.com/ \n" +
            "Some pixel art assests from:\n" +
            "            https://itch.io/game-assets \n" +
            "Special Thanks: Manjot Singh Oberoi, Munish Kumar";
    }


    public void ShowAbout()
    {
        _text.text = "little chad wakes up and\nfinds out his little dog\ngeorge is missing\n" +
            "follow him along in this\nadventure and find george";
    }

    public void HideContent()
    {
        _text.text = "";
    }
}
