using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderPosition : MonoBehaviour
{
    [Tooltip("this Object always try to facing in LateUpdate")]
    public bool keepUpdating;

    [Header("Base Information")]
    public float rotationDegree;
    public float depth;
    public float height;

    [Header("Rotate Horizontal?")]
    [Tooltip("this Object always face baseV3.")]
    public bool lookatBase;

    private Transform parentTraY;

    const float radian2Degree = 180 / Mathf.PI;

    // Use this for initialization
    void Start()
    {

        var objToSpawn = new GameObject("RotationParent");
        parentTraY = objToSpawn.transform;
        parentTraY.SetParent(transform.parent);

        if (transform.parent == null)
            Debug.LogError("CylinderPosition Object MUST be placed under a Game Object");

        transform.SetParent(parentTraY);

        SetTransform(depth, height, rotationDegree);
    }

    public void SetTransform(float _depth, float _height, float _angle)
    {
        parentTraY.eulerAngles = new Vector3(0, rotationDegree, 0);
        transform.localPosition = new Vector3(0, _height, _depth);

        var inDegree = -Mathf.Atan2(_height, _depth) * radian2Degree;

        if (lookatBase)
            transform.localEulerAngles = new Vector3(inDegree, 0, 0);
    }

    private void LateUpdate()
    {
        if (keepUpdating)
            SetTransform(depth, height, rotationDegree);
    }
}