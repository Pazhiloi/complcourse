using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  public float MoveSpeed;
  public float JumpSpeed;
  public float Friction;
  public bool Grounded;

  public float MaxSpeed;
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

    float speedMultiplier = 1f;

    if (Grounded == false)
    {
      speedMultiplier = 0.2f;
    }
    if (rb.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
    {
      speedMultiplier = 0;
    }
    if (rb.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0)
    {
      speedMultiplier = 0;
    }
    rb.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);
    if (Grounded)
    {
      rb.AddForce(-rb.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
    }
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
