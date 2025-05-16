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
    float timeSinceLastAttack = Mathf.Infinity;
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
        mover.MoveTo(target.transform.position, 1f);
      }
      else
      {
        mover.Cancel();
        AttackBehaviour();
      }
    }

    private void AttackBehaviour()
    {
      transform.LookAt(target.transform);
      if (timeSinceLastAttack > timeBetweenAttacks)
      {
        TriggerAttack();
        timeSinceLastAttack = 0;

      }
    }

    private void TriggerAttack()
    {
      animator.ResetTrigger("stopAttack");
      animator.SetTrigger("attack");
    }
   

    // Animation Event
    void Hit()
    {
      if (target == null) return;
      target.TakeDamage(weaponDamage);
    }
    private bool GetIsInRange()
    {
      return Vector3.Distance(transform.position, target.transform.position) < weaponRange;
    }

    public bool CanAttack(GameObject combatTarget)
    {
      if (combatTarget == null) return false;

      Health targetToTest = combatTarget.GetComponent<Health>();
      return targetToTest != null && !targetToTest.IsDead();
    }

    public void Attack(GameObject combatTarget)
    {
      actionScheduler.StartAction(this);
      target = combatTarget.GetComponent<Health>();
    }

    public void Cancel()
    {
      StopAttack();
      target = null;
    }

    private void StopAttack()
    {
      animator.ResetTrigger("attack");
      animator.SetTrigger("stopAttack");
    }
  }
}
