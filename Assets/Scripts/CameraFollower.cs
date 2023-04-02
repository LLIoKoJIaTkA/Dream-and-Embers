using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Vector3 offcet;
    [SerializeField] private float smoothing = 3f;


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var nextPosition = Vector3.Lerp(transform.position, targetTransform.position + offcet, Time.deltaTime * smoothing);
        transform.position = nextPosition;
    }
}
