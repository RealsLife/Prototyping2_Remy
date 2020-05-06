using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{


   
    private int _popUpIndex = 0;
    private string _text;
    private float _timer;


    public TutorialFinish TutorialFinish;
    public CameraSwitch CameraSwitch;
    public Text Text;


    void Update()
    {
      
        if (CameraSwitch.EnterTrigger == true)
        {
            switch (_popUpIndex)
        {
            case 0:
                _text = "Kijk links en rechts door je muis te bewegen";
                if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse X") < 0)
                {
                    _popUpIndex++;
                    _text = "Wandel naar voor met pijltje naar boven of W";
                }
                break;
            case 1:
                if (Input.GetAxis("Vertical") > 0)
                {
                    _popUpIndex++;
                    _text = "Wandel naar achter met pijltje naar beneden of S";
                }
                break;
            case 2:
                if (Input.GetAxis("Vertical") < 0)
                {
                    {
                        _popUpIndex++;
                        _text = "Wandel naar rechts met pijltje naar rechts of D";
                    }
                }
                break;
            case 3:
                if (Input.GetAxis("Horizontal") > 0)
                {
                    {
                        _popUpIndex++;
                        _text = "Wandel naar links met pijltje naar links of A";
                    }
                }
                break;
            case 4:
                if (Input.GetAxis("Horizontal") < 0)
                {
                    {
                        _popUpIndex++;
                        _text = "Wandel naar de lichtstraal om verder te gaan";
                    }
                }
                break;
            case 5:
                if (TutorialFinish.Finish == true)
                {
                    _text = "Proficiat je hebt het gevonden!";
                    _timer += Time.deltaTime;

                    if (_timer > 2)
                        _text = "De inleiding is beindigd, nu kan je beginnen!";
                    if (_timer > 4)
                        _text = "Ik blijf de hele tijd bij je om te kijken \n als je alles goed doet in het verkeer";
                    if (_timer > 6)
                        _text = "Succes";
                  
                }
                break;
        }
        Text.text = _text;
        

        }
       
    }
  
}
