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
        MainMove2();
        playerStatistiche.SetDistace(Name, DistanceMove);

    }

    void Move()
    {
        if ((detectObject.GetZ() == ZPos + 1 && detectObject.GetX() == XPos))
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
    }

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

    void MainMove2() {
        if (Input.GetMouseButtonDown(0)) {
            XPos_old = XPos;
            ZPos_old = ZPos;
            ZPos += DistanceMove;
            Move();
        }
    }
}
