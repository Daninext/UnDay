using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fence_Sc : MonoBehaviour
{
    GameObject Point1;
    GameObject Point2;
    GameObject Point3;
    GameObject Point4;
    GameObject Point11;
    GameObject Point22;
    GameObject Point33;
    GameObject Point44;
    GameObject Player;
    bool UPFlag;
    bool DOWNFlag;
    public bool OnFloor;
    public int Rotation;
    PlayerControl Player_Sc;
    GameObject Platform;

    void Start()
    {
        Player = GameObject.Find("Player");
        Player_Sc = Player.GetComponent<PlayerControl>();
        Point1 = Player_Sc.Point1;
        Point2 = Player_Sc.Point2;
        Point3 = Player_Sc.Point3;
        Point4 = Player_Sc.Point4;
        Point11 = Player_Sc.Point11;
        Point22 = Player_Sc.Point22;
        Point33 = Player_Sc.Point33;
        Point44 = Player_Sc.Point44;
        Platform = GameObject.Find("Platform");
    }

    void Update()
    {
        if (UPFlag)
        {
            Rotation = Player_Sc.GetComponent<PlayerControl>().Rotation;
            if (Rotation == 1)
            {
                transform.position = Point11.transform.position;
            } else if (Rotation == 2)
            {
                transform.position = Point22.transform.position;
            } else if (Rotation == 3)
            {
                transform.position = Point33.transform.position;
            } else if (Rotation == 4)
            {
                transform.position = Point44.transform.position;
            }
        } else if (DOWNFlag)
        {
            Rotation = Player_Sc.GetComponent<PlayerControl>().Rotation;
            if (Rotation == 1)
            {
                transform.position = Point1.transform.position;

            } else if (Rotation == 2)
            {
                transform.position = Point2.transform.position;
            } else if (Rotation == 3)
            {
                transform.position = Point3.transform.position;
            } else if (Rotation == 4)
            {
                transform.position = Point4.transform.position;
            }
            DOWNFlag = false;
            OnFloor = true;
        }

        //if ((gameObject.transform.position == Platform.transform.position) && (OnFloor))
        //{
        //    Debug.Log("Да");
        //    //Platform.GetComponent<Platform_Sc>().Win();
        //}
    }

    public void UP()
    {
        UPFlag = true;
    }

    public void DOWN()
    {
        UPFlag = false;
        DOWNFlag = true;
    }

    //void OnTriggerStay2D(Collider2D col)
    //{
    //    Debug.Log(col);
    //    if (col.tag == "Finish")
    //    {
    //        Debug.Log("Да");
    //    }
    //}
}
