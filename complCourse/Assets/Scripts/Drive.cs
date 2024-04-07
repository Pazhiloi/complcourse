using UnityEngine;

public class Drive : MonoBehaviour
{
  public WheelCollider[] WCs;
  public GameObject[] Wheels;
  public float torque = 200;
  public float maxSteerAngle = 30;


  private void Go(float accel, float steer)
  {
    accel = Mathf.Clamp(accel, -1, 1);
    steer = Mathf.Clamp(steer, -1, 1) * maxSteerAngle;
    float thrustTorque = torque * accel;

    for (int i = 0; i < 4; i++)
    {
      WCs[i].motorTorque = thrustTorque;
      if (i < 2)
      {
        WCs[i].steerAngle = steer;
      }

      Quaternion quat;
      Vector3 position;
      WCs[i].GetWorldPose(out position, out quat);
      Wheels[i].transform.position = position;
      Wheels[i].transform.localRotation = quat;
    }

  }

  void Update()
  {
    float a = Input.GetAxis("Vertical");
    float s = Input.GetAxis("Horizontal");
    Go(a, s);
  }
}
