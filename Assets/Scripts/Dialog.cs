using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI TextDisplay;
    public string[] Sentences;
    public float TypingSpeed;
    public GameObject ContinueButton;

    private int _index;

    private void Start()
    {

        StartCoroutine(Type());
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
        if (_index < Sentences.Length - 1)
        {
            _index++;
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
