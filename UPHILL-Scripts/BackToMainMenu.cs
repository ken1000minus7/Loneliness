using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BackToMainMenu : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;

    void Start()
    {
        StartCoroutine(BackToMM());
    }

    IEnumerator BackToMM()
    {
        yield return new WaitForSeconds(2.5f);
        _text.text = "BACK TO MAIN MENU";
    }

    public void ClickBack()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
