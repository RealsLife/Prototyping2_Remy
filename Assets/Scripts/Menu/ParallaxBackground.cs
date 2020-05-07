using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Parallax scrolling script that should be assigned to a layer
/// </summary>
public class ParallaxBackground : MonoBehaviour
{
    public RawImage img;
    public float speed;
    private Rect rect;

    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        Rect rect = img.uvRect;
        rect.x += speed * Time.deltaTime;
        rect.x =(float)System.Math.Round(rect.x, 4);

        img.uvRect = rect;
    }
}
