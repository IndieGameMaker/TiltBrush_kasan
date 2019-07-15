using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DrawMgr : MonoBehaviour
{
    [Header("Controller Setup")]
    public SteamVR_Input_Sources rightHand  = SteamVR_Input_Sources.RightHand;
    //트리거 버튼의 클릭 여부
    public SteamVR_Action_Boolean trigger   = SteamVR_Actions.default_InteractUI;
    //컨트롤러의 6DOF 
    public SteamVR_Action_Pose pose         = SteamVR_Actions.default_Pose;

    [Header("Line Renderer Setup")]
    private LineRenderer line;
    public float lineWidth = 0.01f;
    public Color lineColor = new Color(1, 1, 1, 0.8f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.GetStateDown(rightHand))
        {
            CreateLine();
        }
    }

    void CreateLine()
    {
        //LineRenderer 컴포넌트를 저장할 게임오브젝트 생성
        GameObject lineObject = new GameObject("Line");
        line = lineObject.AddComponent<LineRenderer>();
        //LineRenderer에 추가할 머티리얼을 생성하고 연결
        Material mt = new Material(Shader.Find("Unlit/Color"));
        mt.color = lineColor;
        
        //LineRenderer 속성
        line.useWorldSpace = false;
        line.positionCount = 1;
        line.numCapVertices = 20;
        line.widthMultiplier = 0.1f;
        line.startWidth = lineWidth;
        line.endWidth   = lineWidth;
        
        Vector3 position = pose.GetLocalPosition(rightHand);
        line.SetPosition(0, position);
    }
}
