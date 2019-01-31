using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentList : MonoBehaviour {


    Transform point;
    public RectTransform cont;
    public GameObject Comands;
    public GameObject find;
    GameObject Comand;
    Vector3 PosComand;
    //public GameObject Turn;
    public GameObject Com_Mov;
    public GameObject Com_Turn1;
    public GameObject Com_Turn2;
    public GameObject Com_Pickup;
    public GameObject Com_Drop;
    public GameObject Com_IF;
    public GameObject IF_Var;
    //public string txtCom;
    int ComVal;
    public string StartModCom;
    //public string StartMod_Turn;
    float i;

	void Start ()
    {
        Comand = Comands.gameObject;
        point = gameObject.transform;
    }

    void Update ()
    {
        find = GameObject.Find("Label");
        ComVal = Comands.GetComponent<Dropdown>().value;
        if (ComVal == 2)
        {
            PosComand = Comand.transform.position;

            Instantiate(Com_Turn1, new Vector3(Comand.transform.position.x - 26, Comand.transform.position.y, Comand.transform.position.z), Quaternion.identity, point);

            //Instantiate(Turn, new Vector3(Comand.transform.position.x + 100, Comand.transform.position.y, transform.position.z), Quaternion.identity, point);

            Comand.transform.position = new Vector3(PosComand.x, PosComand.y - 35, PosComand.z);

            StartModCom = StartModCom + ComVal;

            Comands.GetComponent<Dropdown>().value = 0;

        } else if (ComVal == 1)
        {
            PosComand = Comand.transform.position;

            Instantiate(Com_Mov, new Vector3(Comand.transform.position.x-9, Comand.transform.position.y, Comand.transform.position.z), Quaternion.identity, point);

            Comand.transform.position = new Vector3(PosComand.x, PosComand.y - 35, PosComand.z);

            StartModCom = StartModCom + ComVal;

            Comands.GetComponent<Dropdown>().value = 0;

        } else if (ComVal == 3)
        {
            PosComand = Comand.transform.position;

            Instantiate(Com_Turn2, new Vector3(Comand.transform.position.x - 26, Comand.transform.position.y, Comand.transform.position.z), Quaternion.identity, point);

            //Instantiate(Turn, new Vector3(Comand.transform.position.x + 100, Comand.transform.position.y, transform.position.z), Quaternion.identity, point);

            Comand.transform.position = new Vector3(PosComand.x, PosComand.y - 35, PosComand.z);

            StartModCom = StartModCom + ComVal;

            Comands.GetComponent<Dropdown>().value = 0;
        } else if (ComVal == 4)
        {
            PosComand = Comand.transform.position;

            Instantiate(Com_Pickup, new Vector3(Comand.transform.position.x - 26, Comand.transform.position.y, Comand.transform.position.z), Quaternion.identity, point);

            Comand.transform.position = new Vector3(PosComand.x, PosComand.y - 35, PosComand.z);

            StartModCom = StartModCom + ComVal;

            Comands.GetComponent<Dropdown>().value = 0;
        } else if (ComVal == 5)
        {
            PosComand = Comand.transform.position;

            Instantiate(Com_Drop, new Vector3(Comand.transform.position.x - 26, Comand.transform.position.y, Comand.transform.position.z), Quaternion.identity, point);

            Comand.transform.position = new Vector3(PosComand.x, PosComand.y - 35, PosComand.z);

            StartModCom = StartModCom + ComVal;

            Comands.GetComponent<Dropdown>().value = 0;
        }
        //else if (ComVal == 6)
        //{
        //    PosComand = Comand.transform.position;

        //    Instantiate(Com_IF, new Vector3(Comand.transform.position.x - 46.5f, Comand.transform.position.y, Comand.transform.position.z), Quaternion.identity, point);

        //    Instantiate(IF_Var, new Vector3(Comand.transform.position.x + 35, Comand.transform.position.y, Comand.transform.position.z), Quaternion.identity, point);

        //    Comand.transform.position = new Vector3(PosComand.x, PosComand.y - 35, PosComand.z);

        //    StartModCom = StartModCom + ComVal;

        //    Comands.GetComponent<Dropdown>().value = 0;
        //}
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        cont.sizeDelta = new Vector2(0, cont.rect.height + 60);
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(190.3f, -cont.rect.height + 20);
    }
}
