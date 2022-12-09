using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowFPS : MonoBehaviour
{
    public TMP_Text fpsText;
    public float deltaTime;

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();
        //Debug.Log(fps);

    }
}
