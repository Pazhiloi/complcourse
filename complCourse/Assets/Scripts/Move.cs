using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
   public float Speed;


   private void FixedUpdate() {
    // GetComponent<Rigidbody>().velocity = transform.forward * Speed;
    GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * Speed * Time.deltaTime);
   }
}
