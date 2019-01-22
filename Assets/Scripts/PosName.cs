using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PosName : MonoBehaviour
{

    //position name
    //-------------------------
    public GameObject LHand;
    public GameObject LShould;

    public GameObject RHand;
    public GameObject RShould;

    public GameObject Head;

    public GameObject Water;


    //position of parts
    //----------------------------
    [HideInInspector] public Vector3 _LHand, _LShould;
    [HideInInspector] public Vector3 _RHand, _RShould;
    [HideInInspector] public Vector3 _pHead;

    [HideInInspector] public Vector3[,] _Pos = new Vector3[5,11];

    //other
    //-----------------------------


    [Range(0f, 0.25f)]
    public float delFrame;                    //Frame Management

    public bool LH,LS,RH,RS,HE;
    public bool Grv;
    public bool Stop;

    public int LowMag, HighMag;

    public float LowRad, HighRad;

    [HideInInspector] public int Counter = 1;   //Memory Management
    [HideInInspector] public float TimeCounter = 0;
    //public int PositionNumber = 2;      //取得する部位の数  
}



