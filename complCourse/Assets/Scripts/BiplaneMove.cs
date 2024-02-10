using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiplaneMove : MonoBehaviour
{
  public Rigidbody rb;
  public float ConstantForceValue = 0.2f;
  public float ForceValue;
  public float TorqueValue;

  private void FixedUpdate()
  {
    rb.AddForce(transform.forward * ConstantForceValue, ForceMode.VelocityChange);

    if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
    {
      rb.AddForce(transform.forward * ForceValue, ForceMode.VelocityChange);
    }

    float horizontalInput = Input.GetAxis("Horizontal");

    rb.AddTorque(transform.right * horizontalInput * TorqueValue, ForceMode.VelocityChange);
  }
}
