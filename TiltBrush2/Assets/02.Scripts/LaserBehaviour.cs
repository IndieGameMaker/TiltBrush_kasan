using UnityEngine;
using UnityEngine.EventSystems;

public class LaserBehaviour : MonoBehaviour
{
    void OnEnable()
    {
        TouchMgr.OnLaserEnter += this.LaserEnter;
        TouchMgr.OnLaserExit  += this.LaserExit;
    }

    void OnDisable()
    {
        TouchMgr.OnLaserEnter -= this.LaserEnter;
        TouchMgr.OnLaserExit  -= this.LaserExit;
    }

    void LaserEnter(GameObject obj)
    {
        if (obj == this.gameObject)
        {
            PointerEventData data = new PointerEventData(EventSystem.current);
            ExecuteEvents.Execute(obj, data, ExecuteEvents.pointerEnterHandler);
        }
    }

    void LaserExit()
    {
        PointerEventData data = new PointerEventData(EventSystem.current);
        ExecuteEvents.Execute(this.gameObject, data, ExecuteEvents.pointerExitHandler);        
    }
}
