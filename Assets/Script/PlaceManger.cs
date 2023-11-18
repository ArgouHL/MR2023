using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManger : MonoBehaviour
{
    [SerializeField] private TargetPlace[] allplace;

    public static PlaceManger instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        foreach(var p in allplace)
        {
            p.HideOutLine();
        }
    }

    public void CheckAllDone()
    {       
        foreach (var p in allplace)
        {
            if (!p.isDone)
                return;
        }
        Invoke("DoorAlam", 2);
       
    }

    private void DoorAlam()
    {
        DoorCtr.instance.belling();
    }
}
