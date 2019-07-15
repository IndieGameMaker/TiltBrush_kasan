using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMgr : MonoBehaviour
{
    public delegate void LaserEnterHandler(GameObject obj); //델리게이트 선언
    public static event LaserEnterHandler OnLaserEnter;     //이벤트 선언

    public delegate void LaserExitHandler();
    public static event LaserExitHandler OnLaserExit;

    //OnLaserEnter 이벤트 생성 함수
    public static void RaiseLaserEnter(GameObject obj)
    {
        //이벤트 호출(발생)
        OnLaserEnter(obj);
    }

    public static void RaiseLaserExit()
    {
        OnLaserExit();
    }

}
