using System;
using UnityEngine;

[Serializable]
public class CellData
{

    public int X;
    public int Z;
    public Vector3 WorldPosition;
    public bool IsValid = true;

    public CellData(int _xPos, int _zPos, Vector3 _worldPosition)
    {
        X = _xPos;
        Z = _zPos;
        WorldPosition = _worldPosition;
    }

    public void SetValidity(bool _isValid)
    {
        IsValid = _isValid;
    }

}