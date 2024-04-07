using UnityEngine;

public class Drive : MonoBehaviour
{
  public WheelCollider WC;
  public float torque = 200;
    void Start()
    {
        WC = GetComponent<WheelCollider>();
    }

    private void Go(float accel){
      accel = Mathf.Clamp(accel, -1, 1);
      float thrustTorque = torque * accel; 
      WC.motorTorque = thrustTorque;

      Quaternion quat;
      Vector3 position;
      WC.GetWorldPose(out position, out quat);
      transform.position = position;
      transform.rotation = quat;
    }

    void Update()
    {
        float a  = Input.GetAxis("Vertical");
        Go(a);
    }
}
