using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platform_Sc : MonoBehaviour
{
    public GameObject WinLog;
    GameObject Canvas;
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
    }

    void Update()
    {
        
    }

    public void Win()
    {
        WinLog.SetActive(true);
    }

    //void OnTriggerStay2D(Collider2D col)
    //{
    //    Debug.Log(col);
    //    if ((col.tag == "Fence") && (col.transform.position == gameObject.transform.position) && (col.GetComponent<Fence_Sc>().OnFloor == true))
    //    {
    //        Instantiate(WinLog, new Vector3(0, 0, 0), Quaternion.identity, Canvas.transform);
    //    }
    //}
}
