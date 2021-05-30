using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerZoneTwo : MonoBehaviour
{
    [SerializeField]
    private Image blackk;
    [SerializeField]
    private Animator animm;

    private Player _player;

    [SerializeField]
    private DialogueZoneTwo _DialogueManager;

    private bool _wizardHint = false;
    private bool _initialMovement = false;

    string[] cheatCode = new string[] { "c", "h", "a", "d", "n", "u", "b" };
    int index = 0;

    private void Start()
    {
        _player = GetComponent<Player>();
        _DialogueManager = GameObject.Find("MyDialogueManagerZ2").GetComponent<DialogueZoneTwo>();
    }

    private void Update()
    {
        if (!_initialMovement && transform.position.x < -8f)
        {
            transform.Translate(Vector3.right * 2f * Time.deltaTime);
        }
        else if (!_initialMovement)
        {
            _initialMovement = true;
            SetMovementTrue();
        }

        // stairs thing
        if (transform.position.x > 8.15f)
        {
            _player.playerMovement = false;
            transform.Translate(Vector3.up * 6f * Time.deltaTime);
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
            StartCoroutine(Fading());
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_wizardHint && other.tag is "hint4")
        {
            _player.playerMovement = false;
            _wizardHint = true;
            _DialogueManager.StartWizardConvo();
        }

        if (other.tag is "nextScene")
        {
            StartCoroutine(Fading());
        }
    }


    public void SetMovementTrue()
    {
        _player.playerMovement = true;
    }

    IEnumerator Fading()
    {
        animm.SetBool("Fade", true);
        yield return new WaitUntil(() => blackk.color.a == 1);
        SceneManager.LoadScene("ZoneThree");
    }
}
