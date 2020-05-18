using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.HID.HID;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _levelButton;
    public static int _levelsUnlocked = 1;

    // Start is called before the first frame update
    void Start()
    {
        LockLevels();
   
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i <= _levelsUnlocked-1; i++)
        {
            _levelButton[i].SetActive(true);
        }
    }

    private void LockLevels()
    {
        for (int i = 0; i <= _levelButton.Length; i++)
        {
            _levelButton[i].SetActive(false);
        }
    }

    public static void UnlockNewLevel(int level)
    {
        if (level > _levelsUnlocked)
        {
            _levelsUnlocked = level;
        }
    }
}
