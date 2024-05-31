using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColorControl : MonoBehaviour
{
    [SerializeField] private Material groundMetarial;

    [SerializeField] private Color[] colors;

    int colorCount = 0; 

    [SerializeField] private float variable;    

    [SerializeField] private float time;

    float instantTime;

    void Update()
    {
        ColorChangingTime();
        CheckGroundValue();
    }

    void ColorChangingTime()
    {
        if (instantTime <= 0)
        {
            CheckColorValue();
            instantTime = time;
        }
        else
        {
            instantTime -= Time.deltaTime;
        }
    }

    void CheckColorValue()
    {
        colorCount++;

        if (colorCount >= colors.Length)
        {
            colorCount = 0;
        }
    }

    void CheckGroundValue()
    {
        groundMetarial.color = Color.Lerp(groundMetarial.color, colors[colorCount], variable * Time.deltaTime);
    }

    void OnDestroy()
    {
        groundMetarial.color = colors[1];
    }
}
