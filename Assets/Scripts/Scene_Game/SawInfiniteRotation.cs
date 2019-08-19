using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawInfiniteRotation : MonoBehaviour
{
    private float rotationSpeed;

    private void Awake()
    {
        rotationSpeed = 200;
    }

    private void FixedUpdate()
    {
        transform.Rotate (0, 0, rotationSpeed * Time.deltaTime);
    }
}
