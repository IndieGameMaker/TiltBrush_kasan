using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PaletteMgr : MonoBehaviour
{
    public Transform paletteObj;

    //왼손 컨트롤러
    public SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    //트랙패드 클릭
    public SteamVR_Action_Boolean trackPad = SteamVR_Actions.default_Teleport;
    //트랙패드 터치위치
    public SteamVR_Action_Vector2 trackPadPosition = SteamVR_Actions.default_TrackpadPosition;

    // Update is called once per frame
    void Update()
    {
        //왼손 컨트롤러의 트랙패드를 클릭했을 경우
        if (trackPad.GetStateDown(leftHand))
        {
            Vector2 pos = trackPadPosition.GetAxis(leftHand);
            Debug.LogFormat("trackpad x={0}, y={1}", pos.x, pos.y);

            //트랙패드의 오른쪽을 클릭
            if (pos.x >= 0.2f)
            {
                Hashtable ht = new Hashtable();
                ht.Add("z", -90.0f);
                ht.Add("time", 0.2f);
                ht.Add("easetype", iTween.EaseType.easeOutBounce);

                iTween.RotateAdd(paletteObj.gameObject, ht);
            }
            else if (pos.x <= -0.2f)
            {
                Hashtable ht = new Hashtable();
                ht.Add("z", 90.0f);
                ht.Add("time", 0.2f);
                ht.Add("easetype", iTween.EaseType.easeOutBounce);

                iTween.RotateAdd(paletteObj.gameObject, ht);                
            }
        }
    }
}
