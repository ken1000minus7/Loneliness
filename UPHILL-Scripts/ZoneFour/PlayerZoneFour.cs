using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerZoneFour : MonoBehaviour
{
    [SerializeField]
    private Image blackk;
    [SerializeField]
    private Animator animm;

    private Player _player;

    [SerializeField]
    private GameObject _dogCollar;

    private bool _initialDone = false;
    private bool _dogChat = false;
    private bool _noticed = false;
    private bool _foxConvo = false;

    [SerializeField]
    private DialogueZoneFour _dialogueManager;

    string[] cheatCode = new string[] { "c", "h", "a", "d", "n", "u", "b" };
    int index = 0;


    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _dialogueManager = GameObject.Find("DialogueZ4").GetComponent<DialogueZoneFour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_initialDone && transform.position.x < -8)
        {
            transform.Translate(Vector3.right * 2.5f * Time.deltaTime);
        }
        else if (!_initialDone)
        {
            _initialDone = true;
            SetMovementTrue();
        }

        // stairs thing
        if (transform.position.x > 8.27f)
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
        if (!_dogChat && other.tag is "hint6")
        {
            _player.playerMovement = false;
            _dogChat = true;
            _dogCollar.transform.position = new Vector3(0, 3.95f, 0);
            _dogCollar.transform.localScale = new Vector3(5, 5, 0);
            _dialogueManager.StartDogConvo();
        }

        if(!_foxConvo && other.tag is "fox")
        {
            _player.playerMovement = false;
            _foxConvo = true;
            _dialogueManager.StartFoxConvo();
        }

        if (!_noticed && other.tag is "notice")
        {
            _noticed = true;
            _player.playerMovement = false;
            _dialogueManager.Notice();
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
        SceneManager.LoadScene("ZoneFive");
    }
}
