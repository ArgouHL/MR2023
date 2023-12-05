using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorCtr : MonoBehaviour
{
   [SerializeField] private AudioSource bell;
    [SerializeField] private AudioSource Door, Lock;
    [SerializeField] private Outline handleOutline;
    [SerializeField] private Transform handle;
    [SerializeField] private AudioClip BellSoound,UnlockSoound, DoorSound;
    private bool canOpenDoor = false;
    public static DoorCtr instance;
    private void Awake()
    {
        instance = this;
    }

    public void belling()
    {
        canOpenDoor = true;
        Debug.Log("Beel");
        handleOutline.enabled = true;
        StartCoroutine(BellIE());
    }

    private IEnumerator BellIE()
    {
        bell.PlayOneShot(BellSoound);
        yield return new WaitForSeconds(1.7f);
        bell.PlayOneShot(BellSoound);
    }

    public void OpenDoor()
    {
        if (!canOpenDoor)
            return;
        canOpenDoor = false;
        Lock.PlayOneShot(UnlockSoound);
        LeanTween.rotateLocal(handle.gameObject, new Vector3(0, 0, 40), 0.7f).setEase(LeanTweenType.easeInQuart).setDelay(0.2f);
        StartCoroutine(DelayOpenDoor());

    }


    private  IEnumerator DelayOpenDoor()
    {
        yield return new WaitForSeconds(1.7f);
        Door.PlayOneShot(DoorSound);
        LeanTween.rotate(gameObject, new Vector3(0, 90, 0), 2).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() =>
        LeanTween.delayedCall(3, () => SceneFade.instance.FadeOutAndLoad(2, Color.white))
        );
    }
}
