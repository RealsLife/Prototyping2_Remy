using UnityEngine;
using UnityEngine.UI;

public class PlayerProfile : MonoBehaviour
{
    public static string _playerName;
    public GameObject _inputField;

    public void Update()
    {
        Debug.Log(_playerName);
    }

    public void StoreName()
    {
        _playerName = _inputField.GetComponent<Text>().text;
    }
}
