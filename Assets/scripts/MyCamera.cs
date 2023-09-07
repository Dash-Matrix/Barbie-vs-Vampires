using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{

    public float Yaxis;
    public float Xaxis;
    public float RotationSensitivity = 8f;

    public float RotationMin = 0;
    public float RotationMax = 10;

    float smoothTime = 0.18f;

    public Transform target;
    Vector3 targetRotation;
    Vector3 currentVel;

    public bool enableMobileInputs = false;

    public FixedTouchField touchField;
    // Update is called once per frame
    void LateUpdate()
    {
        if (GameManager.gameEnded)
        {
            this.enabled = false;
            return;
        }



        if (enableMobileInputs)
        {
            Yaxis += touchField.TouchDist.x * RotationSensitivity;
            Xaxis -= touchField.TouchDist.y * RotationSensitivity;
        }
        else
        {
            Yaxis += Input.GetAxis("Mouse X") * RotationSensitivity;
            Xaxis -= Input.GetAxis("Mouse Y") * RotationSensitivity;
        }
        Xaxis = Mathf.Clamp(Xaxis, RotationMin, RotationMax);




        targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(Xaxis, Yaxis), ref currentVel, smoothTime);
        transform.eulerAngles = targetRotation;

        transform.position = target.position - transform.forward * 2f;

    }
}
