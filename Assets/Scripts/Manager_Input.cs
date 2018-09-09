using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Manager : MonoBehaviour {

    CylinderPosition controllTarget;

    public float RotatingFactor = 1f;

    void UserInputUpdate()
    {
        float hor = Input.GetAxis("Horizontal");
        controllTarget.rotationDegree += hor * RotatingFactor;
    }
}
