using UnityEngine;

public class Car : MonoBehaviour
{
  public Rigidbody Rigidbody;
  public WheelCollider LeftFrontWheel;
  public WheelCollider RightFrontWheel;

  public float MaxMotorTorque = 10f;
  public float MaxSteerAngle = 30f;

  private void Start() {
    Rigidbody.centerOfMass = new Vector3(0, -0.478f, 0);
  }

  private void FixedUpdate()
  {
    LeftFrontWheel.motorTorque = RightFrontWheel.motorTorque = Input.GetAxis("Vertical") * MaxMotorTorque;
    LeftFrontWheel.steerAngle = RightFrontWheel.steerAngle = Input.GetAxis("Horizontal") * MaxSteerAngle;
  }
}
