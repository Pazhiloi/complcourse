using Rpg.Core;
using RPG.Core;
using RPG.Movement;
using UnityEngine;
namespace RPG.Combat
{
  public class Fighter : MonoBehaviour, IAction
  {
    [SerializeField] private float weaponRange = 2f;
    [SerializeField] private float timeBetweenAttacks = 1f;
    [SerializeField] private float weaponDamage = 5f;
    Transform target;
    float timeSinceLastAttack = 0;
    Mover mover;
    ActionScheduler actionScheduler;
    Animator animator;

    private void Awake()
    {
      mover = GetComponent<Mover>();
      actionScheduler = GetComponent<ActionScheduler>();
      animator = GetComponent<Animator>();
    }

    private void Update()
    {
      timeSinceLastAttack += Time.deltaTime;
      if (target == null) return;

      if (!GetIsInRange())
      {
        mover.MoveTo(target.position);
      }
      else
      {
        mover.Cancel();
        AttackBehaviour();
      }
    }

    private void AttackBehaviour()
    {
      if (timeSinceLastAttack > timeBetweenAttacks)
      {
        animator.SetTrigger("attack");
        timeSinceLastAttack = 0;
        
      }
    }
    // Animation Event
    void Hit()
    {
      Health healthComponent = target.GetComponent<Health>();
      healthComponent.TakeDamage(weaponDamage);
    }
    private bool GetIsInRange()
    {
      return Vector3.Distance(transform.position, target.position) < weaponRange;
    }

    public void Attack(CombatTarget combatTarget)
    {
      actionScheduler.StartAction(this);
      target = combatTarget.transform;
    }

    public void Cancel()
    {
      target = null;
    }

    
  }
}
