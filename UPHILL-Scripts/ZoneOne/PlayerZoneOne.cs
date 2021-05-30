using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerZoneOne : MonoBehaviour
{
    [SerializeField]
    private Image blackk;
    [SerializeField]
    private Animator animm;

    private Player _player;

    [SerializeField]
    private DialogueZoneOne _DialogueManager;

    private bool _dogHint = false;
    private bool _guardHint = false;
    private bool _kemptyConvo = false;
    private bool _initialMovement = false;

    string[] cheatCode = new string[] { "c", "h", "a", "d", "n", "u", "b" };
    int index = 0;

    private void Start()
    {
        _player = GetComponent<Player>();
        _DialogueManager = GameObject.Find("DialogueZ1").GetComponent<DialogueZoneOne>();
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
        if (!_dogHint && other.tag is "hint1")
        {
            _player.playerMovement = false;
            _dogHint = true;
            _DialogueManager.TypeDogConveOne();
        }

        if (!_guardHint && other.tag is "hint2")
        {
            _player.playerMovement = false;
            _guardHint = true;
            _DialogueManager.TypeGuardConvo();
        }

        if (!_kemptyConvo && other.tag is "hint3")
        {
            _player.playerMovement = false;
            _kemptyConvo = true;
            _DialogueManager.TypeKemptyConvo();
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
        SceneManager.LoadScene("ZoneTwo");
    }
}
