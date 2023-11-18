using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObj : MonoBehaviour
{
    [SerializeField] private bool canGrab = true;
    public ObjTag objTag;
    public TargetPlace[] places;
    public bool CanGrab
    {
        get { return canGrab; }
    }
    [SerializeField] private Outline _outline;


    private void Start()
    {
        _outline = GetComponentInChildren<Outline>();

    }
    public void GrabUp(Transform hand)
    {
        Debug.Log("GrapUp");
        canGrab = false;
        transform.parent = hand;
        transform.localPosition = Vector3.zero;
        transform.rotation = hand.rotation;
        _outline.enabled = false;
        foreach (var p in places)
        { p.ShowOutline(); }
    }

    public void SetOutLine(bool enable)
    {

        if (canGrab)
            _outline.enabled = enable;
    }


}

public enum ObjTag { BookA, BookB, PhotoA, MediA }