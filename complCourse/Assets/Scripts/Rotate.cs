using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
  private void Update()
  {
    // transform.eulerAngles += new Vector3(0, 0, 5f * Time.deltaTime);
    // transform.Rotate(0, 50f * Time.deltaTime, 0);
  }

  private void FixedUpdate() {
    // GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 1f, 0);

    // Vector3 resultEuler = transform.eulerAngles + new Vector3(0, 1f, 0);
    GetComponent<Rigidbody>().MoveRotation(transform.rotation * Quaternion.AngleAxis(5, Vector3.up));
  }
}
