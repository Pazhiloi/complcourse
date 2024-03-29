using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
  public EnemyHealth EnemyHealth;
  public bool DieOnAnyCollision;
  private void OnCollisionEnter(Collision other)
  {
    if (other.rigidbody)
    {
      if (other.rigidbody.GetComponent<Bullet>())
      {

        EnemyHealth.TakeDamage(1);
      }
    }
    if (DieOnAnyCollision)
    {
      EnemyHealth.TakeDamage(10000);
    }

  }
}
