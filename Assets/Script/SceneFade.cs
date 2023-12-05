using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class SceneFade : MonoBehaviour
{

    public static SceneFade instance;
    public CanvasGroup fadeui;
    public Image img;
    private void Awake()
    {

        instance = this;


    }


    private void Start()
    {
        img = GetComponentInChildren<Image>();
        FadeIn();
    }
    private void FadeIn()
    {
        LeanTween.value(1, 0, 2).setOnUpdate((float v) => fadeui.alpha = v).setOnComplete(() => fadeui.alpha = 0);
    }

    public void FadeOutAndLoad(int index)
    {
        FadeOutAndLoad(index, Color.black);
    }



    public void FadeOutAndLoad(int index, Color color)
    {
        img.color = color;
        LeanTween.value(0, 1, 2).setOnUpdate((float v) => fadeui.alpha = v).setOnComplete(() =>
        {
            fadeui.alpha = 1;
            SceneManager.LoadScene(index);
        });
    }
}
