using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private GrabableObj[] allObj;

    public static ObjectManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
     //   SceneFade.instance.FadeIn();
    }


    public void SetOutline(bool b)
    {
        foreach (var o in allObj)
        {
            o.SetOutLine(b);
        }
        Debug.Log("SetAllObjOutLine:"+b);
    }
}
