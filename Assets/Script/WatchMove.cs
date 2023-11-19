using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchMove : MonoBehaviour
{
    [SerializeField] private Transform org;
    [SerializeField] private float speed = 2;
    Coroutine MoveCoro;

    public void MoveFront()
    {
        if (MoveCoro != null)
            return;
        MoveCoro= StartCoroutine(MoveIE(Vector3.forward));
    }

    public void MoveLeft()
    {
        if (MoveCoro != null)
            return;
        MoveCoro = StartCoroutine(MoveIE(Vector3.left));
    }

    public void MoveRight()
    {
        if (MoveCoro != null)
            return;
        MoveCoro = StartCoroutine(MoveIE(Vector3.right));
    }

    public void MoveBack()
    {
        if (MoveCoro != null)
            return;
        MoveCoro = StartCoroutine(MoveIE(Vector3.back));
    }

    public void MoveFL()
    {
        if (MoveCoro != null)
            return;
        MoveCoro = StartCoroutine(MoveIE(new Vector3(-1,0,1)));
    }

    public void MoveFR()
    {
        if (MoveCoro != null)
            return;
        MoveCoro = StartCoroutine(MoveIE(new Vector3(1, 0, 1)));
    }

    public void MoveBL()
    {
        if (MoveCoro != null)
            return;
        MoveCoro = StartCoroutine(MoveIE(new Vector3(-1, 0, -1)));
    }

    public void MoveBR()
    {
        if (MoveCoro != null)
            return;
        MoveCoro = StartCoroutine(MoveIE(new Vector3(   1, 0, -1)));
    }


    public void StopMove()
    {

        if (MoveCoro == null)
            return;
        StopCoroutine(MoveCoro);
        MoveCoro = null;
    }


    public void Move(Vector3 dirction)
    {
        float rotateAngle = org.rotation.eulerAngles.y;
        var way = Quaternion.Euler(new Vector3(0, rotateAngle, 0)) * dirction.normalized;

        org.position += way.normalized * speed * Time.deltaTime;
    }



    IEnumerator MoveIE(Vector3 v)
    {
        while(true)
        {
            Move(v);
            yield return null;
        }
    }

    private void Update()
    {
        transform.rotation = Quaternion.identity;
    }
}
