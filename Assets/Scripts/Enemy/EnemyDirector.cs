using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirector : MonoBehaviour {

    public Manager myManger;
    public GameObject myEnemy01;
    public bool isWorking= false;

    [Header("Settings")]
    [SerializeField]
    private int reproductPerMillisecond = 1000;
    [SerializeField]
    private int storedTime;

    [Header("Debug Info")]
    [SerializeField]
    private MovementPattern currentPatternName;
    [SerializeField]
    private IMovementPattern currentPattern;
    [SerializeField]
    private List<EnemyBehavior> enmList = new List<EnemyBehavior>();

    // Use this for initialization
    private void Start () {
        myEnemy01.SetActive(false);

        ChangeMovementPattern(MovementPattern.Swing);

        myManger.EndGameEvent += Stop;
        isWorking = true;
    }

    // Update is called once per frame
    private void Update () {
        storedTime += (int)(Time.deltaTime * 1000);
	}

    private void FixedUpdate()
    {
        for (var idx = enmList.Count-1; idx >= 0; idx--)
        {
            EnemyStatus eStatus =  enmList[idx].MovementUpdate();

            if (eStatus.reachedOrigin)
            {
                enmList[idx].Destroy();
                enmList.RemoveAt(idx);
            }
                

        }
    }


    private void LateUpdate()
    {
        if (isWorking && storedTime > reproductPerMillisecond)
        {
            currentPattern.MovementUpdate();
            storedTime -= reproductPerMillisecond;
        }
            
    }

    public void Stop()
    {
        isWorking = false;
        myManger.EndGameEvent -= Stop;
    }

    public void ChangeMovementPattern(MovementPattern _mPat)
    {
        switch(_mPat)
        {
            case MovementPattern.Default:
                MovementPattern00 nextPattern = new MovementPattern00();
                nextPattern.ReproduceEnemy = ReproduceEnemy;
                currentPattern = nextPattern;
                break;
            case MovementPattern.Swing:
                MovementPattern01 nextPattern2 = new MovementPattern01();
                nextPattern2.ReproduceEnemy = ReproduceEnemyWithDegree;
                currentPattern = nextPattern2;
                break;
        }

        currentPatternName = _mPat;
    }

    public void ReproduceEnemy()
    {
        GameObject go = Instantiate(myEnemy01,gameObject.transform);
        EnemyBehavior eBehave = go.GetComponent<EnemyBehavior>();
        eBehave.Init();
        enmList.Add(eBehave);

        go.SetActive(true);
    }

    public void ReproduceEnemyWithDegree(int _degree)
    {
        GameObject go = Instantiate(myEnemy01, gameObject.transform);
        EnemyBehavior eBehave = go.GetComponent<EnemyBehavior>();
        eBehave.Init();
        eBehave.cPosition.rotationDegree = _degree;
        enmList.Add(eBehave);
        go.SetActive(true);
    }
}

public enum MovementPattern{
    Default,
    Swing
}

public interface IMovementPattern{
    void MovementUpdate();
}

public class MovementPattern00 : IMovementPattern
{
    public string name = "Default";

    public Action ReproduceEnemy;

    public void MovementUpdate()
    {
        ReproduceEnemy();
    }
}

public class MovementPattern01: IMovementPattern
{
    public string name="Swing";

    public Action<int> ReproduceEnemy;

    private int startDegree = 0;
    private int degreeDelta = 15;


    public void MovementUpdate()
    {
        if (startDegree > 90 || startDegree < -90)
            degreeDelta *= -1;

        startDegree += degreeDelta;

        ReproduceEnemy(startDegree);

    }
}