using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightBehaviour : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField]
    private GameObject _greenLightObject;

    [SerializeField]
    private GameObject _redLightObject;

    [Header("Lit light materials")]
    [SerializeField]
    private Material _greenLightLitMaterial;

    [SerializeField]
    private Material _redLightLitMaterial;

    [Header("Unlit light materials")]
    [SerializeField]
    private Material _greenLightUnlitMaterial;
    
    [SerializeField]
    private Material _redLightUnlitMaterial;

    [Header("Optional: only add if object has orange light")]
    [SerializeField]
    private GameObject _orangeLightObject;
    [SerializeField]
    private Material _orangeLightLitMaterial;
    [SerializeField]
    private Material _orangeLightUnlitMaterial;


    [Header("Variables")]
    [SerializeField]
    [Range(0, 60)]
    private int _timeLightStaysRed;

    [SerializeField]
    [Range(0, 60)]
    private int _timeLightStaysOrange;

    [SerializeField]
    [Range(0, 60)]
    private int _timeLightStaysGreen;

    private bool _hasOrangeLight;

    // Start is called before the first frame update
    void Start()
    {
        if(_orangeLightObject != null)
        {
            _hasOrangeLight = true;
        }
        TurnLightsOff();
        StartCoroutine(TrafficLightFunctionality());
    }

    IEnumerator TrafficLightFunctionality()
    {
        while(true)
        {
            LitRedLight();
            yield return new WaitForSeconds(_timeLightStaysRed);
            LitGreenLight();
            yield return new WaitForSeconds(_timeLightStaysGreen);
            if(_hasOrangeLight)
            {
                LitOrangeLight();
                yield return new WaitForSeconds(_timeLightStaysOrange);
            }
        }
    }

    private void LitGreenLight()
    {
        ChangeLightMaterial(_greenLightObject, _greenLightLitMaterial);
        if (_hasOrangeLight)
            ChangeLightMaterial(_orangeLightObject, _orangeLightUnlitMaterial);
        ChangeLightMaterial(_redLightObject, _redLightUnlitMaterial);
    }

    private void LitOrangeLight()
    {
        ChangeLightMaterial(_greenLightObject, _greenLightUnlitMaterial);
        if (_hasOrangeLight)
            ChangeLightMaterial(_orangeLightObject, _orangeLightLitMaterial);
        ChangeLightMaterial(_redLightObject, _redLightUnlitMaterial);
    }

    private void LitRedLight()
    {
        ChangeLightMaterial(_greenLightObject, _greenLightUnlitMaterial);
        if (_hasOrangeLight)
            ChangeLightMaterial(_orangeLightObject, _orangeLightUnlitMaterial);
        ChangeLightMaterial(_redLightObject, _redLightLitMaterial);
    }

    private void TurnLightsOff()
    {
        ChangeLightMaterial(_greenLightObject, _greenLightUnlitMaterial);
        if (_hasOrangeLight)
            ChangeLightMaterial(_orangeLightObject, _orangeLightUnlitMaterial);
        ChangeLightMaterial(_redLightObject, _redLightUnlitMaterial);
    }

    private void ChangeLightMaterial(GameObject light, Material material)
    {
        light.GetComponent<MeshRenderer>().material = material;
    }
}
