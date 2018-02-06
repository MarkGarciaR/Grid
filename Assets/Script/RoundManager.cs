using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour {

    public string NameRound;

    public string GetNameRound() {
        return NameRound;
    }

    public void SetNameRound(string name) {
        NameRound = name;
    }

    public void Start()
    {
        NameRound = "Blue";
    }
}
