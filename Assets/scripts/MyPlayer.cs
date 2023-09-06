using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MyPlayer : MonoBehaviour
{
    public float MoveSpeed = 3f;
    public float smoothRotationTime = 0.25f;
    float currentVelocity;
    float currentspeed;
    float speedVelocity;

    


    


    public FixedJoystick joystick;
    Transform cameraTransform;

    public bool enableMobileInputs = false;

    private void Start()
    {
        
        cameraTransform = Camera.main.transform;
    }
    // Update is called once per frame

    
    void Update()
    {

       

        Vector2 input = Vector2.zero;
        if (enableMobileInputs)
        {
            input = new Vector2(joystick.input.x, joystick.input.y);
        }
        else
        {
             input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y,rotation,ref currentVelocity,smoothRotationTime);

        }
        float targetspeed = MoveSpeed * inputDir.magnitude;
        currentspeed = Mathf.SmoothDamp(currentspeed, targetspeed, ref speedVelocity, 0.1f);
        transform.Translate(transform.forward * currentspeed * Time.deltaTime, Space.World);
    }

   

}
