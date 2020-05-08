using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay;
    public string[] Sentences;
    public float TypingSpeed;
    public GameObject ContinueButton;
    public string NextScene;

    public Text _buttonText;

    private int _index;

    private void Start()
    {

        StartCoroutine(Type());
        _buttonText.text = "<b>Start</b>";

        
    }
    private void Update()
    {
        if(TextDisplay.text == Sentences[_index])
        {
            ContinueButton.SetActive(true);
        }
     
    }
    IEnumerator Type()
    {
        foreach(char letter in Sentences[_index].ToCharArray())
        {
            TextDisplay.text += letter;
            
            yield return new WaitForSeconds(TypingSpeed);
        }
    }
    public void NextSentence()
    {
        ContinueButton.SetActive(false);

        if (_index == Sentences.Length -1)
        {
            SceneManager.LoadScene(NextScene);
        }

        if (_index < Sentences.Length - 1)
        {
            _index++;
            _buttonText.text = "<b>Verder</b>";
            TextDisplay.text = "";
            StartCoroutine(Type());
        }
        else 
        {
            TextDisplay.text = "";
            ContinueButton.SetActive(false);

        }
        
    }
}
