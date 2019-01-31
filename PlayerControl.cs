using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerControl : MonoBehaviour {

    public int i,j;
    bool flag;
    int MoveLogLength;
    public bool StartMove = false;
    public GameObject Platform;
    public GameObject Comands;
    Transform Position;
    public int Rotation;
    SpriteRenderer SpriteP;
    public Sprite SpR1;
    public Sprite SpR2;
    public Sprite SpR3;
    public Sprite SpR4;
    ContentList Content;
    public GameObject FolFenceP;
    public GameObject Point1;
    bool Point1Flag;
    bool Point1Fence;
    public GameObject Point11;
    public GameObject Point2;
    bool Point2Flag;
    bool Point2Fence;
    bool Point2Finish;
    public GameObject Point22;
    public GameObject Point3;
    bool Point3Flag;
    bool Point3Fence;
    public GameObject Point33;
    public GameObject Point4;
    bool Point4Flag;
    bool Point4Fence;
    public GameObject Point44;
    public GameObject __ContentL;
    int NumFence;
    string ContString;
    double NextMove;
    char[] MoveLog = new char[1];
    


	void Start ()
    {
        Position = gameObject.transform;
        SpriteP = gameObject.GetComponent<SpriteRenderer>();
        Content = __ContentL.GetComponent<ContentList>();
    }
	
	void Update ()
    {
        
        if (!Comands.active)
        {
            StartMove = true;
        }

        Point1Flag = Point1.GetComponent<Point1>().flag;
        Point2Flag = Point2.GetComponent<Point2>().flag;
        Point3Flag = Point3.GetComponent<Point3>().flag;
        Point4Flag = Point4.GetComponent<Point4>().flag;

        Point1Fence = Point1.GetComponent<Point1>().Fence_flag; //Оптимизировать
        Point2Fence = Point2.GetComponent<Point2>().Fence_flag;
        Point3Fence = Point3.GetComponent<Point3>().Fence_flag;
        Point4Fence = Point4.GetComponent<Point4>().Fence_flag;

        Point2Finish = Point2.GetComponent<Point2>().finish;

        if ((StartMove) && (Time.time > NextMove))
        {
            if (!flag)
            {
                StringMove();
            }

            //if (i > MoveLogLength)              Очень странный момент. Не проходит проверку, уходит в цикл  Оптимизировать
            //{
            //  StartMove = false;
            //}
            //Invoke("MoveLogConfirm", 1f);

            MoveLogConfirm();
        }
	}

    private void MoveLogConfirm()
    {
        if (MoveLog[i] == '1')
        {
            if (((Rotation == 1) && (!Point1Flag) && (!Point1Fence)) || ((Rotation == 2) && (!Point2Flag) && (!Point2Fence)) || ((Rotation == 3) && (!Point3Flag) && (!Point3Fence)) || ((Rotation == 4) && (!Point4Flag) && (!Point4Fence)))
            {
                Moving();
            }
            NextMove = Time.time + 1;
            i++;
        }
        else if (MoveLog[i] == '2')
        {
            RotatingLeft();
            NextMove = Time.time + 1;
            i++;
        }
        else if (MoveLog[i] == '3')
        {
            RotationRight(); ;
            NextMove = Time.time + 1;
            i++;
        }
        else if (MoveLog[i] == '4')
        {
            if (NumFence == 0 && ((Point1Fence) || (Point2Fence) || (Point3Fence) || (Point4Fence)))
            { 
                if ((Rotation == 1) && (Point1Fence))
                {
                    Point1.GetComponent<Point1>().UPFlag = true;
                }
                else if ((Rotation == 2) && (Point2Fence))
                {
                    Point2.GetComponent<Point2>().UPFlag = true;
                }
                else if ((Rotation == 3) && (Point3Fence))
                {
                    Point3.GetComponent<Point3>().UPFlag = true;
                }
                else if ((Rotation == 4) && (Point4Fence))
                {
                    Point4.GetComponent<Point4>().UPFlag = true;
                }
                NumFence++;
            }
            NextMove = Time.time + 1;
            i++;
        }
        else if (MoveLog[i] == '5')
        {
            if (NumFence == 1)
            {
                NumFence = 0;
                if ((Rotation == 1) && (!Point1Flag) && (!Point1Fence))
                {
                    Point1.GetComponent<Point1>().DOWNFlag = true;
                } else if ((Rotation == 2) && (!Point2Flag) && (!Point2Fence))
                {
                    if (Point2Finish)
                    {
                        Point2.GetComponent<Point2>().DOWNFlag = true;
                        Platform.GetComponent<Platform_Sc>().Win();
                    } else
                    {
                        Point2.GetComponent<Point2>().DOWNFlag = true;
                    }
                } else if ((Rotation == 3) && (!Point3Flag) && (!Point3Fence))
                {
                    Point3.GetComponent<Point3>().DOWNFlag = true;
                } else if ((Rotation == 4) && (!Point4Flag) && (!Point4Fence))
                {
                    Point4.GetComponent<Point4>().DOWNFlag = true;
                }
            }
            NextMove = Time.time + 1;
            i++;
        }
    }

    void StringMove ()
    {
        ContString = Content.StartModCom;
        foreach (char c in ContString)
        {
            MoveLog[j] = c;
            j++;
            if (j > MoveLog.Length-1)
            {
                Array.Resize(ref MoveLog, MoveLog.Length + 1);
            }
        }
        MoveLogLength = MoveLog.Length - 2;
        flag = true;
    }

    private void Moving()
    {
        if (Rotation == 1)
        {
            Position.position = new Vector3(Position.position.x - 1, Position.position.y, Position.position.z);
        }
        else if (Rotation == 2)
        {
            Position.position = new Vector3(Position.position.x, Position.position.y + 1, Position.position.z);
        }
        else if (Rotation == 3)
        {
            Position.position = new Vector3(Position.position.x + 1, Position.position.y, Position.position.z);
        }
        else if (Rotation == 4)
        {
            Position.position = new Vector3(Position.position.x, Position.position.y - 1, Position.position.z);
        }
    }

    private void RotatingLeft()
    {
        if (Rotation == 1)
        {
            Rotation = 4;
            SpriteP.sprite = SpR4;
            Point11.SetActive(false);
            Point44.SetActive(true);
        } else if (Rotation == 2)
        {
            Rotation = 1;
            SpriteP.sprite = SpR1;
            Point22.SetActive(false);
            Point11.SetActive(true);
        } else if (Rotation == 3)
        {
            Rotation = 2;
            SpriteP.sprite = SpR2;
            Point33.SetActive(false);
            Point22.SetActive(true);
        } else if (Rotation == 4)
        {
            Rotation = 3;
            SpriteP.sprite = SpR3;
            Point44.SetActive(false);
            Point33.SetActive(true);
        }
    }

    private void RotationRight()
    {
        if (Rotation == 1)
        {
            Rotation = 2;
            SpriteP.sprite = SpR2;
            Point11.SetActive(false);
            Point22.SetActive(true);
        } else if (Rotation  == 2)
        {
            Rotation = 3;
            SpriteP.sprite = SpR3;
            Point22.SetActive(false);
            Point33.SetActive(true);
        } else if (Rotation == 3)
        {
            Rotation = 4;
            SpriteP.sprite = SpR4;
            Point33.SetActive(false);
            Point44.SetActive(true);
        } else if (Rotation == 4)
        {
            Rotation = 1;
            SpriteP.sprite = SpR1;
            Point44.SetActive(false);
            Point11.SetActive(true);
        }
    }
}
