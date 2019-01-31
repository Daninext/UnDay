using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point4 : MonoBehaviour
{
    public bool flag;
    public bool Fence_flag;
    GameObject Fence;
    public GameObject FolFence;
    public GameObject Player;
    int Rotation;
    public bool UPFlag;
    public bool DOWNFlag;

    void Start()
    {

    }

    void Update()
    {
        if (UPFlag)
        {
            Player.GetComponent<PlayerControl>().FolFenceP = Fence;
            Fence.GetComponent<Fence_Sc>().UP();
            UPFlag = false;
        }

        if (DOWNFlag)
        {
            FolFence = Player.GetComponent<PlayerControl>().FolFenceP;
            FolFence.GetComponent<Fence_Sc>().DOWN();
            DOWNFlag = false;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Fence")
        {
            Fence_flag = true;
            if (col != Fence)
            {
                Fence = col.gameObject;
            }
        }
        else
        {
            Fence_flag = false;
        }
        if (col.tag == "Background_Wall")
        {
            flag = true;
        }
        else
        {
            flag = false;
        }
    }
}