using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawInfiniteRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void FixedUpdate()
    {
        transform.Rotate (0, 0, rotationSpeed * Time.deltaTime);
    }
}
