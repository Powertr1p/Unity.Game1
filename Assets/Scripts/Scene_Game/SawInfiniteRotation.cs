using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawInfiniteRotation : MonoBehaviour
{
    private float _rotationSpeed;

    private void Start()
    {
        _rotationSpeed = 200;
    }

    private void FixedUpdate()
    {
        transform.Rotate (0, 0, _rotationSpeed * Time.deltaTime);
    }
}
