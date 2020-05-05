using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightStartPosition
{
    Green,
    Red
}

public enum LightState
{
    Green,
    Orange,
    Red
}

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
    private LightStartPosition _lightStartposition;

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

    private LightState _currentLightState;

    [Header("Dependencies")] 
    [SerializeField] private Collider _redLightCollider;
    public Vector3 ForwardDirectionCarsAreStoppedAt { get { return _forwardDirectionCarsAreStoppedAt.transform.forward; } }
    [SerializeField] private GameObject _forwardDirectionCarsAreStoppedAt;

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

    void FixedUpdate()
    {
        UpdateLightTrigger();
    }

    public LightState GetLightState()
    {
        return _currentLightState;
    }

    IEnumerator TrafficLightFunctionality()
    {
        if(_lightStartposition == LightStartPosition.Red)
        {
            while (true)
            {
                LitRedLight();
                yield return new WaitForSeconds(_timeLightStaysRed);
                LitGreenLight();
                yield return new WaitForSeconds(_timeLightStaysGreen);
                if (_hasOrangeLight)
                {
                    LitOrangeLight();
                    yield return new WaitForSeconds(_timeLightStaysOrange);
                }
            }
        }
        else
        {
            while (true)
            {
                LitGreenLight();
                yield return new WaitForSeconds(_timeLightStaysGreen);
                if (_hasOrangeLight)
                {
                    LitOrangeLight();
                    yield return new WaitForSeconds(_timeLightStaysOrange);
                }
                LitRedLight();
                yield return new WaitForSeconds(_timeLightStaysRed);
            }
        }
    }

    private void LitGreenLight()
    {
        ChangeLightMaterial(_greenLightObject, _greenLightLitMaterial);
        if (_hasOrangeLight)
            ChangeLightMaterial(_orangeLightObject, _orangeLightUnlitMaterial);
        ChangeLightMaterial(_redLightObject, _redLightUnlitMaterial);
        _currentLightState = LightState.Green;
    }

    private void LitOrangeLight()
    {
        ChangeLightMaterial(_greenLightObject, _greenLightUnlitMaterial);
        if (_hasOrangeLight)
            ChangeLightMaterial(_orangeLightObject, _orangeLightLitMaterial);
        ChangeLightMaterial(_redLightObject, _redLightUnlitMaterial);
        _currentLightState = LightState.Orange;
    }

    private void LitRedLight()
    {
        ChangeLightMaterial(_greenLightObject, _greenLightUnlitMaterial);
        if (_hasOrangeLight)
            ChangeLightMaterial(_orangeLightObject, _orangeLightUnlitMaterial);
        ChangeLightMaterial(_redLightObject, _redLightLitMaterial);
        _currentLightState = LightState.Red;
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

    private void UpdateLightTrigger()
    {
        if (GetLightState() == LightState.Red || GetLightState() == LightState.Orange)
        {
            // _redLightCollider.enabled = true;
            _redLightCollider.gameObject.transform.localPosition = Vector3.zero;
        }
        else
        {
            //_redLightCollider.enabled = false;
            _redLightCollider.gameObject.transform.localPosition = new Vector3(0, 0, 3);
        }
    }
}
