using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

  private Rigidbody rb;

  private void Awake() {
    rb = GetComponent<Rigidbody>();
  }
    private void FixedUpdate() {
      float horizontal = Input.GetAxis("Horizontal");
      rb.AddForce(new Vector3(horizontal * 3f, 0, 0));
    }
}
