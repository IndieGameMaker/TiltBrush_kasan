using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_Input_Sources hand;
    private SteamVR_Behaviour_Pose pose;    //6축(6 DOF:Degree of freedom)
    private LineRenderer line;

    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    public float maxDistance = 20.0f;           //광선의 거리
    public Color color = Color.blue;            //기본 색상
    public Color clickedColor = Color.green;    //클릭했을 때의 색상
    
    private Ray ray;
    private RaycastHit hit;
    private Transform tr;

    private GameObject currButton;
    private GameObject pointerPrefab; //Resources pointer 프리팹
    private GameObject pointer;       //스테이지에 생성할 객체

    void Start()
    {
        tr   = GetComponent<Transform>();
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        hand = pose.inputSource; //입력소스 설정

        pointerPrefab = Resources.Load<GameObject>("Pointer");
        pointer = Instantiate<GameObject>(pointerPrefab, tr);

        CreateLaser();
    }

    void CreateLaser()
    {
        line = this.gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.receiveShadows = false;
        
        line.positionCount = 2;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0, 0, maxDistance));

        line.startWidth = 0.03f;
        line.endWidth   = 0.005f;
        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = this.color;

        pointer.transform.position = tr.position + (tr.forward * maxDistance);
    }

    void Update()
    {
        if (Physics.Raycast(tr.position, tr.forward, out hit, maxDistance))
        {
            line.SetPosition(1, new Vector3(0,0,hit.distance));
            TouchMgr.RaiseLaserExit();
            TouchMgr.RaiseLaserEnter(hit.collider.gameObject);
            
            //트리거 버튼 클릭했을 때 클릭 이벤트 발생
            if (trigger.GetStateDown(hand))
            {
                currButton = hit.collider.gameObject;
                ExecuteEvents.Execute( currButton
                                    , new PointerEventData(EventSystem.current)
                                    , ExecuteEvents.pointerClickHandler);
            }
            pointer.transform.position = tr.position
                                        + tr.forward * hit.distance
                                        + hit.normal * 0.01f;
            pointer.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
        else
        {
            pointer.transform.position = tr.position + (tr.forward * maxDistance);
            pointer.transform.rotation = Quaternion.LookRotation(tr.forward);

            currButton = null;
            line.SetPosition(1, new Vector3(0, 0, maxDistance));
            TouchMgr.RaiseLaserExit();
        }
    }
}
