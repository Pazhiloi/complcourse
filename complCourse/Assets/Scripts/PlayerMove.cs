using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public bool Grounded;
    private Rigidbody rb;

    private void Start() {
      rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
      rb.AddForce(Input.GetAxis("Horizontal") * MoveSpeed, 0, 0, ForceMode.VelocityChange);
      rb.AddForce(-rb.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
    }

}
