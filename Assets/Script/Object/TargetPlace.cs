using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlace : MonoBehaviour
{
    [SerializeField] Transform place;
    [SerializeField] Outline outline;
    private bool canPlace=true;
    [SerializeField] private GrabableObj targetObj;
    public ObjTag objTag;

    public bool CanPlace
    {
        get { return canPlace; }
    }

    public GrabableObj TargetObj
    {
        get { return targetObj; }
    }

    public Transform GetPlace()
    {
        return place;
    }

    internal void PlaceDownObj(GrabableObj _grabableObj)
    {
        _grabableObj.transform.parent = place.transform;
        _grabableObj.transform.localPosition = Vector3.zero;
        _grabableObj.transform.localRotation = Quaternion.identity;
        outline.enabled = false;
        canPlace = false;
    }
}
