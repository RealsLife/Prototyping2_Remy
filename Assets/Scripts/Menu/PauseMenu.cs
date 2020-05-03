using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    public static bool _isGamePauzed = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleMenu();
            TogglePauze();
        }
           
    }

    public void ToggleMenu()
    {
        _menu.SetActive(!_menu.activeSelf);
        HandleCursorMode();
    }

    private void TogglePauze()
    {
        _isGamePauzed = !_isGamePauzed;
    }

    private void HandleCursorMode()
    {
        if (_menu.activeSelf)
            Cursor.lockState = CursorLockMode.None;
        else if (!_menu.activeSelf)
            Cursor.lockState = CursorLockMode.Locked;
    }
}
