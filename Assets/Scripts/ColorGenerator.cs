using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Color Generator")]
public class ColorGenerator : ScriptableObject
{
    [SerializeField] [Range(0, 1)] private float _hueMinimum = 0;
    [SerializeField] [Range(0, 1)] private float _hueMaximum = 1f;
    [SerializeField] [Range(0, 1)] private float _valueMinimum = 0;
    [SerializeField] [Range(0, 1)] private float _valueMaximum = 1f;
    [SerializeField] [Range(0, 1)] private float _saturationMinimum = 0;
    [SerializeField] [Range(0, 1)] private float _saturationMaximum = 1f;

    private float _hue;
    private float _value;
    private float _saturation;
    public Color GenerateColor()
    {
        _hue = Random.Range(_hueMinimum, _hueMaximum);
        _value = Random.Range(_valueMinimum, _valueMaximum);
        _saturation = Random.Range(_saturationMinimum, _saturationMaximum);
        return Color.HSVToRGB(_hue, _saturation, _value);
    }
}
