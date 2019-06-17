using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwapCanvasSpace()
    {
        switch (canvas.renderMode)
        {
            case RenderMode.ScreenSpaceOverlay:
                canvas.renderMode = RenderMode.WorldSpace;
                canvas.worldCamera = Camera.main;
                canvas.transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
                canvas.transform.position = new Vector3(-0.5f, 1.5f, 3);
                break;
            case RenderMode.WorldSpace:
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.transform.localScale = new Vector3(1, 1, 1);
                canvas.transform.position = new Vector3(960, 540, 0);
                break;

        }
    }
}
