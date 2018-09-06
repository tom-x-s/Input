﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour {

    public bool startedDoubleTap;
    private float timeSinceFirstTap;

    public float tapInterval;

    // Use this for initialization
    void Start () {
		
	}

    public bool Tap()
    {
        if (Input.touchCount == 0) return false;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Ended)
        {
            return true;
        }
        return false;
    }

    public bool DoubleTap()
    {
        if (Input.touchCount == 0) return false;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Ended)
        {
            if (startedDoubleTap)
            {
                if (timeSinceFirstTap < tapInterval)
                {
                    startedDoubleTap = false;
                    timeSinceFirstTap = 0;
                    return true;
                }
            }
            else
            {
                startedDoubleTap = true;
                timeSinceFirstTap = 0;
                return false;
            }
        }

        return false;
    }




    // Update is called once per frame
    void Update () {

        if (startedDoubleTap)
        {
            timeSinceFirstTap += Time.deltaTime;
            if (timeSinceFirstTap > tapInterval)
            {
                startedDoubleTap = false;
                timeSinceFirstTap = 0;
            }
        }

        if (Input.touchCount == 0) return;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Ended)
        {
            startedDoubleTap = true;
        }

    }
}