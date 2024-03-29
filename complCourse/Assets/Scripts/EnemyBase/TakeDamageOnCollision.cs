using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
  public EnemyHealth EnemyHealth;
  private void OnCollisionEnter(Collision other)
  {
    if (other.rigidbody)
    {
      if (other.rigidbody.GetComponent<Bullet>())
      {

        EnemyHealth.TakeDamage(1);
      }
    }

  }
}
