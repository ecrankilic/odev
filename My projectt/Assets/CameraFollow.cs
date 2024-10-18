using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edeceğimiz obje (top)
    public Vector3 offset; // Kamera ile obje arasındaki mesafe

    void Update()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
        }
    }
}

