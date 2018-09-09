using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public CylinderPosition cPosition;

    [Header("Debug Info")]
    [SerializeField]
    private EnemyStatus currentStatus;

    public void Init()
    {
        currentStatus = new EnemyStatus();
    }

    public void Init(int _degree)
    {
        cPosition.rotationDegree = _degree;
        Init();
    }


    public EnemyStatus MovementUpdate()
    {
        cPosition.depth -= 0.1f;

        if (cPosition.depth < 0)
        {
            currentStatus.reachedOrigin = true;
        }

        return currentStatus;
    }

    public void Destroy()
    {
        Destroy(gameObject);

    }

}

[System.Serializable]
public class EnemyStatus{
    public bool reachedOrigin;
}
