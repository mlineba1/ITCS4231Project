using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    public Camera playerCamera;

    // Update is called once per frame
    void Update()
    {
        Vector3 v = playerCamera.transform.position - transform.position;
        v.x = v.z = 0.0f;
        transform.LookAt(playerCamera.transform.position - v);
        transform.Rotate(0, 180, 0);
    }
}
