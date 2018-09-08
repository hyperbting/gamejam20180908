using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public Countdowner myCountdowner;

    // Use this for initialization
    void Start () {
		
	}

    public void AddMillisecond(int _msec = 1000)
    {
        myCountdowner.AddTime(_msec);
    }
}
