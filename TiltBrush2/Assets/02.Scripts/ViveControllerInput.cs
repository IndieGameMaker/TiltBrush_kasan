using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveControllerInput : MonoBehaviour
{
    //Hand Setting
    public SteamVR_Input_Sources hand = SteamVR_Input_Sources.Any;

    //Trigger Button
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    //Trackpad Click
    public SteamVR_Action_Boolean trackPad = SteamVR_Actions.default_Teleport;
    //Trackpad Touch
    public SteamVR_Action_Boolean trackPadTouch = SteamVR_Actions.default_Trackpad;
    //Trackpad Position(Vector2)
    public SteamVR_Action_Vector2 trackPadPosition 
                                = SteamVR_Actions.default_TrackpadPosition;

    void Start()
    {
        
    }

    void Update()
    {
        if (trigger.GetStateDown(hand))
        {
            Debug.Log(hand + " Click Trigger Button");
        }   

        //TrackPad Click
        if (trackPad.GetStateUp(hand)) 
        {
            Debug.Log("TrackPad Up");
        }

        //TrackPad Touch
        if (trackPadTouch.GetState(hand))
        {
            Vector2 pos = trackPadPosition.GetAxis(hand);
            Debug.LogFormat("Touch Position x={0}, y={1}", pos.x, pos.y);
        }
    }
}
