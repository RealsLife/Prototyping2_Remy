using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{


    public Text Text;
    private int _popUpIndex = 0;
    private string _text;
    
    void Update()
    {

      

        if(_popUpIndex == 0)
        {
            _text = "Kijk links en rechts door je muis te bewegen";
            if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse X") < 0)
            {
                _popUpIndex++;
                _text = "Wandel naar voor met pijltje naar boven of W";
            }
               
        }else if (_popUpIndex == 1)
        {
            if (Input.GetAxis("Vertical") > 0) 
            {
                _popUpIndex++;
                _text = "Wandel naar achter met pijltje naar beneden of S";
            }
        }
        else if (_popUpIndex == 2)
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                {
                    _popUpIndex++;
                    _text = "Wandel naar rechts met pijltje naar rechts of D";
                }
            }
        }
        else if (_popUpIndex == 3)
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                {
                    _popUpIndex++;
                    _text = "Wandel naar links met pijltje naar links of A";
                }
            }
        }
        else if (_popUpIndex == 4)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                {
                    _popUpIndex++;

                }
            }

        }
        Text.text = _text;

    }
}
