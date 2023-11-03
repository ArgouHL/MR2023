using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrabCtr : MonoBehaviour
{
    private GrabableObj _grabableObj;
    private bool canGrab = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (!canGrab)
            return;
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Place"&& _grabableObj != null)
        {
            PlaceDown(collision);
        }
        else if(collision.gameObject.tag == "Object"&& _grabableObj == null)
        {
            PickUpObj(collision);
        }      
    }

    private void PlaceDown(Collision collision)
    {
        TargetPlace _place = collision.transform.GetComponent<TargetPlace>();
        if (!_place.CanPlace)
            return;
        _place.PlaceDownObj(_grabableObj);
        _grabableObj = null;
    }

    private void PickUpObj(Collision collision)
    {
        GrabableObj _obj = collision.transform.GetComponent<GrabableObj>();
        if (!_obj.CanGrab)
            return;
        _obj.GrabUp(this.transform);
        _grabableObj = _obj;
    }

    internal void SetGrabEnable(bool v)
    {
        throw new NotImplementedException();
    }
}
