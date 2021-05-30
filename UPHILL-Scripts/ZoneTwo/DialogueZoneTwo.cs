using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueZoneTwo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _dialogue;

    [SerializeField]
    private TextMeshProUGUI _continueButton;

    private bool _continueBShow = false;

    [SerializeField]
    private PlayerZoneTwo _player;

    [SerializeField]
    private string[] _convo;

    private int _ind = 0;


    private void Start()
    {
        _player = GameObject.Find("PlayerZ2").GetComponent<PlayerZoneTwo>();
    }

    private void Update()
    {
        if (_continueBShow && Input.GetKeyDown(KeyCode.Space))
        {
            ClickContinue();
        }
    }

    public void StartWizardConvo()
    {
        StartCoroutine(TypeConvo(_convo[_ind]));
    }


    IEnumerator TypeConvo(string whatToType)
    {
        yield return new WaitForSeconds(0.5f);
        foreach (char letter in whatToType)
        {
            _dialogue.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(0.05f);
        _continueButton.text = "press space to continue";
        _continueBShow = true;
    }

    public void ClickContinue()
    {
        _continueButton.text = "";
        _continueBShow = false;
        _dialogue.text = "";
        if (_ind < 5)
        {
            _ind++;
            StartCoroutine(TypeConvo(_convo[_ind]));
        }
        else
        {
            _player.SetMovementTrue();
        }
    }
}
 