
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NieuwSpelMenu : MonoBehaviour
{
    [SerializeField]Toggle _checkBoxBoy;
    [SerializeField]Toggle _checkboxGirl;
    [SerializeField] Button _gaVerder;
    [SerializeField] Text _name;
    private int _currentGender;
      enum Gender
    {
        Boy = 0,
        Girl = 1,      
    }
    void Start()
    {
        _currentGender = (int)Gender.Boy;//zet boy toggle aan als eerste gender en meisje uit
        _checkBoxBoy.isOn = true;
    }

    public void CreatePlayer()
    {
        CheckCurrentGenderInUI();
        ProfileSaver._playerProfile._name = _name.text;
        ProfileSaver._playerProfile._gender = _currentGender;
        ProfileSaver.Save();
    
    }

    void CheckCurrentGenderInUI()
    {
        if (_checkBoxBoy.isOn)
        {
            _currentGender = (int)Gender.Boy;
        }
        else
        {
            _currentGender = (int)Gender.Girl;
        }
    }
    void Update()//als gender geselecteerd word check 
    {
        if (_name.text.Length < 1)
        {
            _gaVerder.interactable = false;
        }
        else
        {
            _gaVerder.interactable = true;
        }
    }
}
