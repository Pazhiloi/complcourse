using UnityEngine;

public class Drive : MonoBehaviour
{
  public WheelCollider WC;
  public float torque = 200;
  public float maxSteerAngle = 30;
  public GameObject Wheel;
    void Start()
    {
        WC = GetComponent<WheelCollider>();
    }

    private void Go(float accel, float steer){
      accel = Mathf.Clamp(accel, -1, 1);
      steer = Mathf.Clamp(steer, -1, 1) * maxSteerAngle;
      float thrustTorque = torque * accel; 
      WC.motorTorque = thrustTorque;
      WC.steerAngle = steer;

      Quaternion quat;
      Vector3 position;
      WC.GetWorldPose(out position, out quat);
      Wheel.transform.position = position;
      Wheel.transform.localRotation = quat;
    }

    void Update()
    {
        float a  = Input.GetAxis("Vertical");
        float s  = Input.GetAxis("Horizontal");
        Go(a, s);
    }
}
