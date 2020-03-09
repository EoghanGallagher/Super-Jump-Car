using UnityEngine;
using System.Collections;
using System.Collections.Generic;

    
public class CarController : MonoBehaviour {
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    [SerializeField] private Transform frontLeftWheel;
    [SerializeField] private Transform frontRightWheel;
    [SerializeField] private Transform backLeftWheel;
    [SerializeField] private Transform backRightWheel;
        
    public void FixedUpdate()
    {
        float motor = maxMotorTorque * Input.GetAxis("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");
            
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
                ApplyLocalPositionToVisuals( axleInfo.leftWheel, frontLeftWheel );
                ApplyLocalPositionToVisuals( axleInfo.rightWheel, frontRightWheel );
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }

            //ApplyLocalPositionToVisuals( axleInfo.leftWheel, frontLeftWheel );
            //ApplyLocalPositionToVisuals( axleInfo.rightWheel, frontRightWheel );
        }
    }

    public void ApplyLocalPositionToVisuals( WheelCollider collider, Transform visualWheelTransform )
    { 
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
     
        visualWheelTransform.position = position;
        visualWheelTransform.rotation = rotation;
    }
}
    
[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}