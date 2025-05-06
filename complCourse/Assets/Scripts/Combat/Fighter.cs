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
    Health target;
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
      if (target.IsDead())return;

      if (!GetIsInRange())
      {
        mover.MoveTo(target.transform.position);
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
      target.TakeDamage(weaponDamage);
    }
    private bool GetIsInRange()
    {
      return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
    }

    public void Attack(CombatTarget combatTarget)
    {
      actionScheduler.StartAction(this);
      target = combatTarget.GetComponent<Health>();
    }

    public void Cancel()
    {
      animator.SetTrigger("stopAttack");
      target = null;
    }

    
  }
}
