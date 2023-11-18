using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxCtr : MonoBehaviour
{
    public static SfxCtr instance;
    private AudioSource correctSound;
    private void Awake()
    {
        instance = this;
    }

    public void PlayCorrect()
    {
        correctSound.Play();
    }
}
