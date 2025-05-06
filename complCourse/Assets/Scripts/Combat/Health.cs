using UnityEngine;
namespace RPG.Combat
{
  
public class Health : MonoBehaviour
{
    [SerializeField] private float healthPoints = 100f;
    Animator animator;
    bool isDead;

    private void Awake() {
      animator = GetComponent<Animator>();
    } 

    public bool IsDead(){
      return isDead;
    }

    public void TakeDamage(float damage){
      healthPoints = Mathf.Max(healthPoints - damage, 0);
      if (healthPoints == 0)
      {
        Die();
      }
    }

    private void Die()
    {
      if (isDead) return;
      isDead = true;
      animator.SetTrigger("die");
    }
  }
}
