using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileHeader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _playerNameTextField;
    [SerializeField] private TextMeshProUGUI _genderField;
    //[SerializeField] private TextMeshPro _playerNameTextField;
    //[SerializeField] private TextMeshPro _playerNameTextField;
    //[SerializeField] private TextMeshPro _playerNameTextField;
    private void Start()
    {
        _playerNameTextField.text = ProfileSaver._playerProfile._name;
        if (ProfileSaver._playerProfile._gender == 0)
        {
            _genderField.text = "Jongen";
        }
        else
        {
            _genderField.text = "Meisje";
        }
       
    }
}
