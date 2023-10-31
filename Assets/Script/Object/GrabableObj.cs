using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabableObj :MonoBehaviour
{
    private bool canGrab = false;
    private Outline _outline;
    private Collider _collider;
    private void Start()
    {
        _outline = GetComponent<Outline>();
        _collider = GetComponent<Collider>();
    }
    public void GrabUp(Transform hand)
    {
        transform.parent = hand;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void SetOutLine(bool enable)
    {
        _outline.enabled = enable;
    }
    private void OnCollisionEnter(Collision collision)
    {
          
    }

}
