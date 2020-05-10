using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NieuwSpelMenu : MonoBehaviour
{
    private int _currentGender;
      enum Gender
    {
        Boy = 0,
        Girl = 1,      
    }
    void Start()
    {
        _currentGender = (int)Gender.Boy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
