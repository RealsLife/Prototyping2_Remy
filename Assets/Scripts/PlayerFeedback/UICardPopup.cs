using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICardPopup : MonoBehaviour
{
    public Text TextField;

    public void PlayCardPopup(string cardDescription)
    {
        TextField.text = cardDescription;
        StartCoroutine(CardTimer());
    }

    private IEnumerator CardTimer()
    {
        yield return new WaitForSeconds(2f);
        TextField.text = "";
        this.gameObject.SetActive(false);
    }

}
