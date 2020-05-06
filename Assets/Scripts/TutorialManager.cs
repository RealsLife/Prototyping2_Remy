using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    
    public GameObject[] _popUps;
    [SerializeField] private GameObject _Finish;
    private int _popUpIndex = 0;
    
    void Update()
    {

        for (int i = 0; i < _popUps.Length ; i++)
        {
            if (i == _popUpIndex)
                _popUps[_popUpIndex].gameObject.SetActive(true);
            else
                _popUps[_popUpIndex].gameObject.SetActive(false);
        }

        if(_popUpIndex == 0)
        {
            if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse X") < 0)
                _popUpIndex++;
        }else if (_popUpIndex == 1)
        {
            if (Input.GetAxis("Vertical") > 0) //move forward
                _popUpIndex++;
        }else if (_popUpIndex == 2)
        {
            if (Input.GetAxis("Vertical") < 0) //move back
                _popUpIndex++;
        }else if (_popUpIndex == 3)
        {
            if (Input.GetAxis("Horizontal") > 0) //move right
                _popUpIndex++;
        }else if (_popUpIndex == 4)
        {
            if (Input.GetAxis("Horizontal") < 0) //move left
                _popUpIndex++;
        }
    }
}
