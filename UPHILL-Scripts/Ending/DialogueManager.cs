using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _content;

    [SerializeField]
    private TextMeshProUGUI _thanks;

    [SerializeField]
    private Image _fin;

    [SerializeField]
    private Animator _animm;

    readonly private string _famousLastWords = "You spend the night sitting there with george,\n" +
        "observing the magnificent scenery and taking in\n" +
        "the cold air..breathe...it feels good to be alive.";
    readonly private string _themksVmro = "thanks for playing";

    void Start()
    {
        StartCoroutine(TypeFamousLastWords());
    }


    IEnumerator TypeFamousLastWords()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (char letter in _famousLastWords)
        {
            _content.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        StartCoroutine(TypeThemksBro());
    }


    IEnumerator TypeThemksBro()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (char letter in _themksVmro)
        {
            _thanks.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        _animm.SetBool("Fade", true);
        yield return new WaitUntil(() => _fin.color.a == 1);
        SceneManager.LoadScene("returnRR");
    }
}
