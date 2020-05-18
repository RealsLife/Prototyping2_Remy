
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenMenu : MonoBehaviour
{
    [SerializeField]private Button _verderGaan;
    private void Start()
    {
        //ProfileSaver._playerProfile = new PlayerProfile();
        //ProfileSaver.Load();
      
        //if (ProfileSaver._playerProfile._profileCreated && ProfileSaver._playerProfile._name != "")
        //{
        //    _verderGaan.gameObject.SetActive(true);
        //}
    }

    public void CreateProfile()
    {
        //ProfileSaver._playerProfile._profileCreated = true;
        //ProfileSaver.Save();
    }

}
