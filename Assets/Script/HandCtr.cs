using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCtr : MonoBehaviour
{

    private Coroutine apperTransparent;
    private Coroutine hideTransparent;
    [SerializeField]  private Material  handMat;
    [SerializeField] private float apperenceTime;
    private HandGrabCtr _handGrabCtr;
    [SerializeField] private Animator[] anis;

   private void Start()
    {
     
        _handGrabCtr = GetComponentInChildren<HandGrabCtr>();
    }


    public void ShowHand()
    {
        if (hideTransparent != null)
        {
            StopCoroutine(hideTransparent);
            hideTransparent=null;
        }
          
        if (apperTransparent != null)
            return;
        apperTransparent = StartCoroutine(HandApper());
    }
    public void HideHand()
    {
        if (apperTransparent != null)
        {
            StopCoroutine(apperTransparent);
            apperTransparent = null;
        }
        hideTransparent = StartCoroutine(HandDispper());
    }
    public void UpdatePos(Transform imageTransform)
    {
        transform.position = imageTransform.position/*+new Vector3(-0.05f,0,0)*/;
        transform.rotation = imageTransform.rotation;
    }

    private IEnumerator HandApper()
    {
        float now= handMat.color.a;
        Color handColor = handMat.color;
        while (now<=1)
        {
            now += Time.deltaTime/ apperenceTime;
            handColor.a = now>1? 1:now;
            handMat.color = handColor;
            yield return null;
        }
        apperTransparent = null;
        _handGrabCtr.SetGrabEnable(true);
    }

    private IEnumerator HandDispper()
    {
        _handGrabCtr.SetGrabEnable(false);
        float now = handMat.color.a;
        Color handColor = handMat.color;
        while (now >=0)
        {
            now -= Time.deltaTime/apperenceTime;
            handColor.a = now < 0 ? 0 : now;
            handMat.color = handColor;
            yield return null;
        }
        hideTransparent = null;
    }


    public void SetHandClose(bool b)
    {
        foreach(var a in anis)
        {
            a.SetBool("Close", b);
        }
    }
}
