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

    private Manager myManager;

    // Use this for initialization
    void Start () {
        myManager = GetComponent<Manager>();
        Reset();
    }

    private void Reset()
    {

        currentNumber = 60 * 1000;
        diffcultFactor = 1;

        isRunning = true;
    }

    public void AddTime(int _millisecond)
    {
        currentNumber += _millisecond;
    }


    // Update is called once per frame
    void Update () {

        if (!isRunning)
            return;

        if(currentNumber < 0)
        {
            myManager.EndGameEvent();
            isRunning = false;
            return;
        }


        currentNumber -= (int)(Time.deltaTime * diffcultFactor * 1000);
        myManager.myTextUpdater.UpdateCountDown(currentNumber);
    }
}
