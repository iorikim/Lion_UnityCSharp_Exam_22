using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropMove : MonoBehaviour
{
    [Header("移動速度"), Range(1, 1000)]
    public float MoveSpeed = 1;
        private void Update()
    {
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime, Space.World);
    }
}
