using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Vector3 wallPosition;
    public GameObject target;

    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;

    Canvas canvas;

    bool isScaleLocked;
    enum Axis { X, Y, Z };
    
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    public void SwapCanvasSpace()
    {
        switch (canvas.renderMode)
        {
            case RenderMode.ScreenSpaceOverlay:
                canvas.renderMode = RenderMode.WorldSpace;
                canvas.worldCamera = Camera.main;
                canvas.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
                canvas.transform.position = wallPosition;
                break;
            case RenderMode.WorldSpace:
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.transform.localScale = new Vector3(1, 1, 1);
                canvas.transform.position = new Vector3(960, 540, 0);
                break;

        }
    }
    public void ToggleScaleLock(bool value)
    {
        isScaleLocked = value;
    }
    public void ChangeScaleX(float value)
    {
        if (isScaleLocked)
            ChangeScaleUniform(Axis.X, value);
        else
            target.transform.localScale = new Vector3(value, target.transform.localScale.y, target.transform.localScale.z);
    }
    public void ChangeScaleY(float value)
    {
        if (isScaleLocked)
            ChangeScaleUniform(Axis.Y, value);
        else
            target.transform.localScale = new Vector3(target.transform.localScale.x, value, target.transform.localScale.z);
    }
    public void ChangeScaleZ(float value)
    {
        if (isScaleLocked)
            ChangeScaleUniform(Axis.Z, value);
        else
            target.transform.localScale = new Vector3(target.transform.localScale.x, target.transform.localScale.y, value);
    }
    void ChangeScaleUniform(Axis axis, float value)
    {
        target.transform.localScale = new Vector3(value, value, value);

        switch(axis)
        {
            case Axis.X:
                sliderY.value = value;
                sliderZ.value = value;
                break;
            case Axis.Y:
                sliderX.value = value;
                sliderZ.value = value;
                break;
            case Axis.Z:
                sliderX.value = value;
                sliderY.value = value;
                break;
        }
    }
}
