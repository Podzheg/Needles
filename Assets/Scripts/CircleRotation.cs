using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotation : MonoBehaviour
{
    [SerializeField]
    private SOGameStats stats;
    public float rotationSpeed = 50f;

    private bool canRotate;
    private float angle;

    void Awake()
    {
        canRotate = true;
        rotationSpeed = stats.circleRotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotate)
        {
            RotateTheCircle();
        }
    }

    void RotateTheCircle()
    {
        angle = transform.rotation.eulerAngles.z;
        angle += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
