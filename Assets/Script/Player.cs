using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour{

    public Grid grid;
    public PlayerStatistiche playerStatistiche;
    public DetectObject detectObject;

    public int XPos;
    public int ZPos;

    int XPos_old;
    int ZPos_old;

    int DistanceMove;

    public string Name;

    //Quaternion sinistra = new Vector3 (0f,0f,0f);

    // Use this for initialization
    void Start()
    {
        transform.position = grid.GetWorldPosition(XPos, ZPos);
        transform.position += new Vector3(0f, 0.55f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        //MainMove();
        MainMove2();
        playerStatistiche.SetDistace(Name, DistanceMove);

    }

    void Move()
    {
        if (grid.IsValidPosition(XPos, ZPos))
        {
                Vector3 globalPosition = grid.GetWorldPosition(XPos, ZPos);
                globalPosition += new Vector3(0f, 0.55f, 0f); ;
                transform.DOMove(globalPosition, 0.6f).SetEase(Ease.Linear);
        }
        else
        {
                XPos = XPos_old;
                ZPos = ZPos_old;
        }

    }


    //movimento tramite WASD
    void MainMove() {
        XPos_old = XPos;
        ZPos_old = ZPos;
        DistanceMove = playerStatistiche.GetDistance();
        if (Input.GetKeyDown(KeyCode.A))//Sinistra
        {
            XPos -= DistanceMove;
            Move();
        }
        else if (Input.GetKeyDown(KeyCode.D))//Destra
        {
            XPos += DistanceMove;
            Move();
        }
        else if (Input.GetKeyDown(KeyCode.W))//Su
        {
            ZPos += DistanceMove;
            Move();
        }
        else if (Input.GetKeyDown(KeyCode.S))//Giu
        {
            ZPos -= DistanceMove;
            Move();
        }
    }


    //Movimento tramite doppio click del mouse
    void MainMove2() {
        //Debug.Log(detectObject.GetX() + " - " + detectObject.GetZ());
        int ObjectX = detectObject.GetX();
        int ObjectZ = detectObject.GetZ();
        DistanceMove = playerStatistiche.GetDistance();
        if (Input.GetMouseButtonDown(0)) {
            if (ObjectX == XPos && ObjectZ - 1 == ZPos)
            { //SU
                XPos_old = XPos;
                ZPos_old = ZPos;

                ZPos += DistanceMove;
                Move();
            }
            else if (ObjectX == XPos && ObjectZ + 1 == ZPos)
            { //GIU
                XPos_old = XPos;
                ZPos_old = ZPos;

                ZPos -= DistanceMove;
                Move();
            }
            else if (ObjectX + 1 == XPos && ObjectZ == ZPos)
            { //SINISTRA
                XPos_old = XPos;
                ZPos_old = ZPos;

                XPos -= DistanceMove;
                Move();
            }
            else if (ObjectX - 1 == XPos && ObjectZ == ZPos)
            { //DESTRA
                XPos_old = XPos;
                ZPos_old = ZPos;

                XPos += DistanceMove;
                Move();
            }
        } 
    }
}
