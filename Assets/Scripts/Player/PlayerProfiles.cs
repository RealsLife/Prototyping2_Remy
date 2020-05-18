using UnityEngine;
using UnityEngine.UI;

public class PlayerProfiles : MonoBehaviour
{
    public static string _playerName;
    public GameObject _inputField;

    public static int _trophies;
    public Text _trophieUi;

    public void Update()
    {
        //Debug.Log(_playerName);
        _trophieUi.text = _trophies.ToString();
    }

    public void StoreName()
    {
        _playerName = _inputField.GetComponent<Text>().text;
    }
}
