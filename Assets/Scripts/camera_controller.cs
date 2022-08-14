using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    public void CamTilt(float input)
    {
        float zRotation = 20f * input;
        Debug.Log(zRotation);
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.z += zRotation;
        transform.localRotation = Quaternion.Euler(rotation);
    }
}
