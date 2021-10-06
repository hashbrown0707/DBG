using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_xin_Test : MonoBehaviour
{

    public delegate void TestDelegate(); // 初次進入戰鬥 或 上一輪結束 
    public static event TestDelegate TestEvent;

    public delegate void TestDelegate2(); // 初次進入戰鬥 或 上一輪結束 
    public static event TestDelegate2 TestEvent2;
    // Start is called before the first frame update
    void Awake()
    {

        A_xin_Test.TestEvent+=ItNotNull;
        
    }

    private void Start()
    {


        A_xin_Test.TestEvent.Invoke();
        A_xin_Test.TestEvent2.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void ItNotNull() {
        Debug.Log("AAAAAAAAAAAAAA");
    }
}
