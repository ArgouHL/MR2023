using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObj :MonoBehaviour
{
    private bool canGrab = true;
    public ObjTag objTag;
    public bool CanGrab
    {
        get { return canGrab; }
    }
    private Outline _outline;

  
    private void Start()
    {
        _outline = GetComponent<Outline>();
       
    }
    public void GrabUp(Transform hand)
    {
        Debug.Log("GrapUp");
        canGrab = false;
        transform.parent = hand;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        _outline.enabled = false;
    }

    public void SetOutLine(bool enable)
    {
        _outline.enabled = enable;
    }
    

}

public enum ObjTag { BookA,BookB ,PhotoA,MediA}