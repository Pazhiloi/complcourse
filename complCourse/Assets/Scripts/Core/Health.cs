using UnityEngine;
namespace RPG.Core
{
  
public class Health : MonoBehaviour
{
    [SerializeField] private float healthPoints = 100f;
    Animator animator;
    ActionScheduler actionScheduler;
    bool isDead;

    private void Awake() {
      actionScheduler = GetComponent<ActionScheduler>();
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
      actionScheduler.CancelCurrentAction();
    }
  }
}
