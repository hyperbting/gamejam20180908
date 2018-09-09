using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public CylinderPosition cPosition;

    [Header("Debug Info")]
    [SerializeField]
    private EnemyStatus currentStatus;

    public void Init(int _degree = 0)
    {
        cPosition.rotationDegree = _degree;
        currentStatus = new EnemyStatus();
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
}

[System.Serializable]
public class EnemyStatus{
    public bool reachedOrigin;
}
