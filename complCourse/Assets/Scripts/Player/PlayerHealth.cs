using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
  public int Health = 5;
  public int MaxHealth = 8;

  private bool _invulnerable = false;

  public AudioSource TakeDamageSound;
  public AudioSource AddHealthSound;

  public void TakeDamage(int damageValue)
  {
    if (_invulnerable == false)
    {
      Health -= damageValue;
      if (Health <= 0)
      {
        Health = 0;
        Die();
      }
      _invulnerable = true;
      Invoke("StopInvulnerable", 1f);
      TakeDamageSound.Play();
    }
  }

  private void StopInvulnerable(){
    _invulnerable = false;
  }

  public void AddHealth(int healthValue)
  {
    Health += healthValue;
    if (Health > MaxHealth)
    {
      Health = MaxHealth;
    }
    AddHealthSound.Play();
  }

  private void Die()
  {
    Debug.Log("You lose");
  }


}
