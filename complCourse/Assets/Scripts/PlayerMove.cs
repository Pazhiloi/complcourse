using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  public float MoveSpeed;
  public float JumpSpeed;
  public float Friction;
  public bool Grounded;
  private Rigidbody rb;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      if (Grounded)
      {
        rb.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
      }
    }
  }

  private void FixedUpdate()
  {
    rb.AddForce(Input.GetAxis("Horizontal") * MoveSpeed, 0, 0, ForceMode.VelocityChange);
    rb.AddForce(-rb.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
  }

  private void OnCollisionStay(Collision other)
  {

    for (int i = 0; i < other.contactCount; i++)
    {
      float angle = Vector3.Angle(other.contacts[i].normal, Vector3.up);
      if (angle < 45f)
      {
        Grounded = true;
      }
    }

    
  }

  private void OnCollisionExit(Collision other)
  {
    Grounded = false;
  }

}
