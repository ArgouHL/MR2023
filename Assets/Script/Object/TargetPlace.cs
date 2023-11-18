using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlace : MonoBehaviour
{
    [SerializeField] Transform place;
    public Outline outline;
    private bool canPlace = true;
    //[SerializeField] private GrabableObj targetObj;
    public ObjTag objTag;
    public bool isDone = false;

    public bool CanPlace
    {
        get { return canPlace; }
    }

    //public GrabableObj TargetObj
    //{
    //    get { return targetObj; }
    //}

    public Transform GetPlace()
    {
        return place;
    }

    internal void PlaceDownObj(GrabableObj _grabableObj)
    {
        if (!canPlace)
            return;
        _grabableObj.transform.parent = null ;
        _grabableObj.transform.position = place.position;        
        _grabableObj.transform.rotation = place.rotation;
        foreach (var p in _grabableObj.places)
        {
            p.outline.enabled = false;
        }
        canPlace = false;
        isDone = true;
    }

    internal void ShowOutline()
    {
        if (!canPlace)
            return;
        outline.enabled = true;
    }

    internal void HideOutLine()
    {

        outline.enabled = false;
    }
}
