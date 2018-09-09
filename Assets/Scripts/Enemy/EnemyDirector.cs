using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDirector : MonoBehaviour {


    public GameObject myEnemy01;


    [Header("Settings")]
    [SerializeField]
    private int reproductPerMillisecond = 1000;
    [SerializeField]
    private int storedTime;

    [Header("Debug Info")]
    [SerializeField]
    private List<EnemyBehavior> enmList = new List<EnemyBehavior>();

    // Use this for initialization
    private void Start () {
        myEnemy01.SetActive(false);

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
        if (storedTime > reproductPerMillisecond)
        {
            ReproduceEnemy();
            storedTime -= reproductPerMillisecond;
        }
            
    }

    public EnemyBehavior ReproduceEnemy()
    {
        GameObject go = Instantiate(myEnemy01,gameObject.transform);
        EnemyBehavior eBehave = go.GetComponent<EnemyBehavior>();
        eBehave.Init();
        enmList.Add(eBehave);

        go.SetActive(true);
        return eBehave;
    }
}

public interface IMovementPattern{
    void MovementUpdate();

}

public class MovementPattern00 : IMovementPattern
{
    public string name = "Default";

    public void MovementUpdate()
    {

    }
}

public class MovementPattern01: IMovementPattern
{
    public string name="Swing";

    private int startDegree = 0;
    private int degreeDelta = 15;
    public void MovementUpdate()
    {
        startDegree += 15;
        if (startDegree > 90 || startDegree < -90)
            degreeDelta *= -1;

        ReproduceEnemy(startDegree);

    }

    public void ReproduceEnemy(int _degree)
    {

    }
}