using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  private Rigidbody rb;
  public Transform CameraCenter;

  public float TorqueValue;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
    rb.maxAngularVelocity = 500f;
  }
  private void FixedUpdate()
  {
    rb.AddTorque(CameraCenter.right * Input.GetAxis("Vertical") * TorqueValue);
    rb.AddTorque(-CameraCenter.forward * Input.GetAxis("Horizontal") * TorqueValue);
  }
}
