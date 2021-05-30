using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueZoneOne : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _dialogue;

    [SerializeField]
    private TextMeshProUGUI _continueButton;

    private bool _continueBShow = false;

    [SerializeField]
    private PlayerZoneOne _player;

    readonly private string _convoOne = "you (to yourself): those are george's footsteps. he must be up ahead.";
    readonly private string _convoTwo = "Guard: You are not allowed in here\n" +
        "you: I wasn’t going there anyway";
    readonly private string _convoThree = "You see Mr.Kempty’s house as you pass by. Always found that dude creepy. And what kinda name is that anyway?";

    private void Start()
    {
        _player = GameObject.Find("PlayerZ1").GetComponent<PlayerZoneOne>();
    }

    private void Update()
    {
        if (_continueBShow && Input.GetKeyDown(KeyCode.Space))
        {
            ClickContinue();
        }
    }

    public void TypeDogConveOne()
    {
        StartCoroutine(TypeConvo(_convoOne));
    }

    public void TypeGuardConvo()
    {
        StartCoroutine(TypeConvo(_convoTwo));
    }

    public void TypeKemptyConvo()
    {
        StartCoroutine(TypeConvo(_convoThree));
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
        _dialogue.text = "";
        _player.SetMovementTrue();
        _continueBShow = false;
    }
}
