using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
  public int Health;

  public UnityEvent EventOnTakeDamage;

  public void TakeDamage(int damageValue){
    Health -= damageValue;
    if (Health <= 0)
    {
      Die();
    }
    EventOnTakeDamage.Invoke();
  }

  public void Die(){
    Destroy(gameObject);
  }
}
