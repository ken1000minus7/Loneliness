using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private ButtonScript _buttons;

    [SerializeField]
    private ContentScript _content;

    [SerializeField]
    private AudioSource _music;

    private bool _isEscapeActive = false;

    void Awake()
    {
        GameObject A = GameObject.FindGameObjectWithTag("music");
        Destroy(A);
    }

    private void Start()
    {
        _buttons = GameObject.Find("ButtonsManager").GetComponent<ButtonScript>();
        _content = GameObject.Find("ContentManager").GetComponent<ContentScript>();
        _music = GameObject.Find("Music").GetComponent<AudioSource>();

        _buttons.ShowAllHideEscape();
    }


    private void Update()
    {
        if (_isEscapeActive && Input.GetKeyDown(KeyCode.Escape))
        {
            ClickEscape();
        }
    }


    public void ClickStart()
    {
        _content.HideContent();
        _buttons.HideAllButtons();
        StartCoroutine(FadeMusic());
    }

    IEnumerator FadeMusic()
    {
        float startVolume = _music.volume;

        while (_music.volume > 0)
        {
            _music.volume -= startVolume * Time.deltaTime / 0.1f;
            yield return null;
        }
        SceneManager.LoadScene("MOMConvo");
    }


    public void ClickEscape()
    {
        _isEscapeActive = false;
        _content.HideContent();
        _buttons.ShowAllHideEscape();
    }

    public void ClickAbout()
    {
        _content.ShowAbout();
        _buttons.HideAllShowEscape();
        _isEscapeActive = true;
    }

    public void ClickCredits()
    {
        _content.ShowCredits();
        _buttons.HideAllShowEscape();
        _isEscapeActive = true;
    }
}
