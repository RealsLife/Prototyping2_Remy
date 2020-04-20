using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            ToggleMenu();
    }

    public void ToggleMenu()
    {
        _menu.SetActive(!_menu.activeSelf);
        HandleCursorMode();
    }

    private void HandleCursorMode()
    {
        if (_menu.activeSelf)
            Cursor.lockState = CursorLockMode.None;
        else if (!_menu.activeSelf)
            Cursor.lockState = CursorLockMode.Locked;
    }
}
