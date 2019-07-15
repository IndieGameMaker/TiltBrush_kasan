using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;
using Valve.VR.Extras;  //SteamVR_LaserPointer

public class CastEventToUI : MonoBehaviour
{
    private SteamVR_LaserPointer laserPointer;

    void OnEnable()
    {
        laserPointer = GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn    += OnPointerEnter;
        laserPointer.PointerOut   += OnPointerExit;
        laserPointer.PointerClick += OnPointerClick;
    }

    //이벤트 연결 해지
    void OnDisable()
    {
        laserPointer.PointerIn    -= OnPointerEnter;
        laserPointer.PointerOut   -= OnPointerExit;
        laserPointer.PointerClick -= OnPointerClick;      
    }

    void OnPointerEnter(object sender, PointerEventArgs e)
    {
        IPointerEnterHandler enterHandler = e.target.GetComponent<IPointerEnterHandler>();
        if (enterHandler == null) return;
        
        PointerEventData data = new PointerEventData(EventSystem.current);
        //Pointer Enter 호출시키는 이벤트
        enterHandler.OnPointerEnter(data);
    }

    void OnPointerExit(object sender, PointerEventArgs e)
    {
        IPointerExitHandler enterHandler = e.target.GetComponent<IPointerExitHandler>();
        if (enterHandler == null) return;

        PointerEventData data = new PointerEventData(EventSystem.current);
        //Pointer Exit 호출시키는 이벤트
        enterHandler.OnPointerExit(data);
    }

    void OnPointerClick(object sender, PointerEventArgs e)
    {
        IPointerClickHandler enterHandler = e.target.GetComponent<IPointerClickHandler>();
        if (enterHandler == null) return;
        
        PointerEventData data = new PointerEventData(EventSystem.current);
        //Pointer Exit 호출시키는 이벤트
        enterHandler.OnPointerClick(data);        
    }


}
