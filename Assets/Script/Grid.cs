using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public GameObject casella;
    public List<CellData> Cells = new List<CellData>();
    public float CellSize = -1;
    public int xSize;
    public int zSize;
    public string NameTile;
    public int Width = 0, Height = 0;

    public float DistanceTile;

    Material material;


    private void Awake()
    {
        Cells = new List<CellData>();
        GridSize(Width, Height);

        //material = casella.GetComponent<Renderer>().material;
    }

    void GridSize(int x, int z)
    {
        xSize = x;
        zSize = z;

        CellSize = casella.transform.localScale.x + DistanceTile;

        for (int _x = 0; _x < x; _x++)
        {
            for (int _z = 0; _z < z; _z++)
            {
                
                Cells.Add(new CellData(_x, _z, new Vector3(_x * CellSize, transform.position.y, _z * CellSize), NameTile));
            }
        }


        for (int _x = 0; _x < x; _x++)
        {
            for (int _z = 0; _z < z; _z++)
            {
                CellData cell = FindCell(_x, _z);
                // Debug
                if (cell.IsValid)
                    Instantiate(casella, cell.WorldPosition, casella.transform.rotation, transform);
            }
        }


        SetCity();
        ChangeColorTileCity();
    }

    void SetCity() {
        FindCell(0, 2).SetNameTile("A");
        FindCell(2, 1).SetNameTile("B");
        FindCell(3, 3).SetNameTile("C");
        FindCell(4, 0).SetNameTile("D");
        FindCell(4, 4).SetNameTile("E");
        FindCell(6, 3).SetNameTile("F");
        FindCell(7, 1).SetNameTile("G");
        FindCell(9, 2).SetNameTile("H");
    }

    void ChangeColorTileCity() {
        string ControlCity;
        for (int _x = 0; _x < Width; _x++)
        {
            for (int _z = 0; _z < Height; _z++)
            {

                ControlCity = FindCell(_x, _z).GetNameTile();
                if (ControlCity != "")
                    //material.color = Color.red;
                    Debug.Log(ControlCity);
            }
        }
    }

    

    #region API

    public CellData FindCell(int x, int z)
    {
        return Cells.Find(c => c.X == x && c.Z == z);
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        foreach (CellData cell in Cells)
        {
            if (cell.X == x && cell.Z == z)
            {
                return cell.WorldPosition;
            }
        }
        return Cells[0].WorldPosition;
    }



    public bool IsValidPosition(int x, int z)
    {
        if (x < 0 || z < 0)
            return false;
        if (x > xSize - 1 || z > zSize - 1)
            return false;

        return true;
    }

        #endregion
}
