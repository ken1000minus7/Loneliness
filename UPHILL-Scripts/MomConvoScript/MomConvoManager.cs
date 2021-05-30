using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MomConvoManager : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI _momConvo;

    [SerializeField]
    private TextMeshProUGUI _continueButton;

    private bool _continueisActive = false;

    public readonly string convoOne = "Chad: Ugh. wha..t time is it \n\n" +
    "Mom(shouts) : It’s night time already and you wake up now!!!\nWhat did I tell you about sleeping Late huh?\n\n" +
    "you say nothing, as you stare into the deep void, zoning out.\nIt was pretty late last night.\n\n" +
    "All the demons they don’t let me sleep, forget it mom won’t understand You glance around for georgie.\n\n" +
    "Chad: Hey George! Where are you buddy?\n\nYou say as you walk out...";

    string[] cheatCode = new string[] { "c", "h", "a", "d", "n", "u", "b" };
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypeMomConvo());
    }

    private void Update()
    {
        if (_continueisActive && Input.GetKeyDown(KeyCode.Space))
        {
            ClickContinue();
        }

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(cheatCode[index]))
            {
                index++;
            }
            else
            {
                index = 0;
            }
        }
        if (index == cheatCode.Length)
        {
            ClickContinue();
        }
    }


    IEnumerator TypeMomConvo()
    {
        foreach (char letter in convoOne)
        {
            _momConvo.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.05f);
        _continueButton.text = "CONTINUE";
        _continueisActive = true;
    }


    public void ClickContinue()
    {
        SceneManager.LoadScene("ZoneOne");
    }
}
