using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class LoadToPlay : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] ARSession aR;
  
    void Start()
    {
        LeanTween.delayedCall(3, () =>
        {
            SceneManager.LoadScene(1);
             aR.Reset();
        }
        );
    }

    // Update is called once per frame
    void Update()
    {

    }
}
