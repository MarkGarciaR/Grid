using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObject : MonoBehaviour {
	
    public float XPosition, ZPosition;
    float Size;

    Transform dir;

    bool IsActive = false;

    Vector3 TilePosition,CellPosition;

    public Grid grid;

    int _x, _z;

    
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                   
                    XPosition = hit.transform.position.x;
                    ZPosition = hit.transform.position.z;
                    IsActive = true;

                    TilePosition = new Vector3(XPosition, hit.transform.position.y, ZPosition);

                    for (int x=0; x<=10; x++) {
                        for (int z=0; z<=4; z++) {
                            CellPosition = grid.GetWorldPosition(x,z);
                            if (CellPosition == TilePosition) {
                                _z = z;
                                _x = x;
                                /*Debug.Log("Torvato " + _x + " - " + _z);
                                Debug.Log("Pos " + XPosition + " - " + ZPosition);*/
                                break;
                            }
                                
                        }
                    }

                    //dir.position = new Vector3(XPosition + Size/2, hit.transform.position.y + gameObject.GetComponent<BoxCollider>().bounds.size.y / 2, ZPosition - Size/2);
                    
                }
            }
        }

	}

    public float GetPositionX() {
        float _X = XPosition;
        return _X;
    }

    public float GetPositionZ()
    {
        float _Z = ZPosition;
        return _Z;
    }

    public int GetZ()
    {
        return _z;
    }

    public int GetX()
    {
        return _x;
    }

    public bool GetActive() {
        return IsActive;
    }

    private void Start()
    {
        //Size = gameObject.GetComponent<BoxCollider>().bounds.size.x;
        //dir = GameObject.FindGameObjectWithTag("Player").transform;

    }
}
