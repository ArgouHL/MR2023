using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageTrackCtr : MonoBehaviour
{
    private ARTrackedImageManager _aRTrackedImageManager;
    [SerializeField]
    private HandCtr arhand;


    private void Awake()
    {
        _aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        _aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }



    private void OnDisable()
    {
        _aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }
    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {

        foreach (var arImage in args.updated)
        {
            if (arImage.referenceImage.name != arhand.name)
                return;
            if (arImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
            {
            //    arhand.ShowHand();
                arhand.UpdatePos(arImage.transform);
            }
            else if (arImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Limited || arImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.None)
            {
               // arhand.HideHand();
            }


        }

    }


   
}
