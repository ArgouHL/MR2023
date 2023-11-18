using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrabCtr : MonoBehaviour
{
    [SerializeField] private GrabableObj _grabableObj;
    [SerializeField] private HandCtr handCtr;
    private bool canGrab = true;
    private void OnCollisionEnter(Collision collision)
    {
       
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Place") && _grabableObj != null)
        {
            PlaceDown(collision);
        }
        else if (collision.gameObject.CompareTag("Object") && _grabableObj == null)
        {
            if (!canGrab)
                return;
            PickUpObj(collision);
        }
        else if (collision.gameObject.CompareTag("Door") && _grabableObj == null)
        {
            collision.transform.GetComponentInParent<DoorCtr>().OpenDoor();
        }
    }

    private void PlaceDown(Collision collision)
    {

        TargetPlace _place;
        if(!collision.transform.TryGetComponent<TargetPlace>(out _place))
            _place= collision.transform.GetComponentInParent<TargetPlace>();
        if (!_place.CanPlace)
            return;
        if (_place.objTag != _grabableObj.objTag)
            return;
        _place.PlaceDownObj(_grabableObj);
        handCtr.SetHandClose(false);
        _grabableObj = null;
        PlaceManger.instance.CheckAllDone();
        ObjectManager.instance.SetOutline(true);
        SfxCtr.instance.PlayCorrect();
        Debug.Log("PlaceDown");
    }

    private void PickUpObj(Collision collision)
    {
        
        GrabableObj _obj = collision.transform.GetComponent<GrabableObj>();
        if (!_obj.CanGrab)
            return;
        handCtr.SetHandClose(true);
        ObjectManager.instance.SetOutline(false);
        _obj.GrabUp(this.transform);
        _grabableObj = _obj;
    }

    internal void SetGrabEnable(bool v)
    {
        canGrab = v;
    }
}
