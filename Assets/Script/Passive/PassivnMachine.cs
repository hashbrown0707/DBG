using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PassivnMachine :MonoBehaviour
{

    //刻意將每個階段都分為三階段 模仿Animator  進入時 執行中、離開時

    public delegate void PassiveList(PassiveEvent eventType); // 初次進入戰鬥 或 上一輪結束 
    public static event PassiveList passiveList;


    void Start()
    {
        LoadPassiveDataFromJson();
    }

    void LoadPassiveDataFromJson() {
        TextAsset JsonTextFile = Resources.Load("PassiveData") as TextAsset;
        if( JsonTextFile!=null )
        {
            var Ps = JsonUtility.FromJson<PassiveData>(JsonTextFile.text);

        }
    }

    /// <summary>
    /// 廣播給所有遺物 遺物會根據收到的 PassiveEvent 來決定自己需不需要執行
    /// <example>
    /// <code>
    /// Passive_Broadcast(PassiveEvent.OnEnterBattlePrePare)
    /// </code>
    /// </example>
    /// </summary>
    /// <param name="eventType"></param>
    void Passive_Broadcast(PassiveEvent eventType) { 

        if( passiveList!=null )
        {
            passiveList.Invoke(eventType);
        }
    }
}


////使用Serializable序列化IdolEvent,否则无法在Editor中显示
//[Serializable]
//public class PassiveListner :UnityEvent<PassiveItem>
//{

//}

