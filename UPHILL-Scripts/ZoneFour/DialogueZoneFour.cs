using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueZoneFour : MonoBehaviour
{
    readonly private string _notice = "As you are walking, you notice something on the ground!";
    readonly private string _dog = "IT’S GEORGE’S COLLAR! HE MUST BE AROUND SOMEWHERE";


    [SerializeField]
    private TextMeshProUGUI _dialogue;

    [SerializeField]
    private TextMeshProUGUI _continueButton;

    private bool _continueBShow = false;

    [SerializeField]
    private PlayerZoneFour _player;

    [SerializeField]
    private string[] _convo;

    private int _ind = 0;


    private void Start()
    {
        _player = GameObject.Find("PlayerZ4").GetComponent<PlayerZoneFour>();
    }

    private void Update()
    {
        if (_continueBShow && Input.GetKeyDown(KeyCode.Space))
        {
            ClickContinue();
        }
    }

    public void StartFoxConvo()
    {
        StartCoroutine(TypeConvo(_convo[_ind]));
    }


    public void Notice()
    {
        StartCoroutine(TypeStuff(_notice));
    }

    public void StartDogConvo()
    {
        StartCoroutine(DogConvo(_dog));
    }

    IEnumerator DogConvo(string whatToType)
    {
        foreach (char letter in whatToType)
        {
            _dialogue.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        _continueButton.text = "press space to continue";
        _continueBShow = true;
    }

    IEnumerator TypeStuff(string whatToType)
    {
        foreach (char letter in whatToType)
        {
            _dialogue.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1f);
        _dialogue.text = "";
        _player.SetMovementTrue();
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
        if (_ind < 6)
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
