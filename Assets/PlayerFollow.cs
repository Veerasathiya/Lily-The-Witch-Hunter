using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform playerT;
    private Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float smoothFactor = 0.5f;

    private void Start()
    {
        _cameraOffset = transform.position - playerT.position;
        Debug.Log(_cameraOffset);
    }
    private void LateUpdate()
    {
        Vector3 newPos = playerT.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
       
    }
}
