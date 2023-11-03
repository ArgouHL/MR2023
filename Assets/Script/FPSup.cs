using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        Application.targetFrameRate = 999;
#endif
    }

    
}
