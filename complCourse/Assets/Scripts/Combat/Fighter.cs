using RPG.Movement;
using UnityEngine;
namespace RPG.Combat
{
  public class Fighter : MonoBehaviour
  {
    [SerializeField] private float weaponRange = 2f;
     Transform target;
    Mover mover;
    bool isInRange;

    private void Awake()
    {
      mover = GetComponent<Mover>();
    }

    private void Update()
    {
      isInRange = Vector3.Distance(transform.position, target.position) < weaponRange;
      if (target != null && !isInRange)
      {
        mover.MoveTo(target.position);
      }
      else
      {
        mover.Stop();
      }
    }
    public void Attack(CombatTarget combatTarget)
    {
      target = combatTarget.transform;
    }
  }
}
