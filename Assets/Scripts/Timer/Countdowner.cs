using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdowner : MonoBehaviour {

    public bool isRunning = false;

    [Header("Debug Info")]
    [SerializeField]
    private int currentNumber;

    [SerializeField]
    private float diffcultFactor;

    // Use this for initialization
    void Start () {
        Reset();
    }

    private void Reset()
    {

        currentNumber = 6 * 1000;
        diffcultFactor = 1;

        isRunning = true;
    }


    // Update is called once per frame
    void Update () {

        if (!isRunning)
            return;

        if(currentNumber <0)
        {
            Debug.Log("End");
            isRunning = false;
            return;
        }


        currentNumber -= (int)(Time.deltaTime * diffcultFactor * 1000);
    }
}
