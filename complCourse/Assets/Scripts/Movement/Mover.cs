using RPG.Core;
using UnityEngine;
using UnityEngine.AI;
namespace RPG.Movement
{

  public class Mover : MonoBehaviour, IAction
  {
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    private Animator animator;
    private Health health;
    ActionScheduler actionScheduler;

    private void Awake()
    {
      agent = GetComponent<NavMeshAgent>();
      animator = GetComponent<Animator>();
      actionScheduler = GetComponent<ActionScheduler>();
      health = GetComponent<Health>();
    }

    void Update()
    {
      agent.enabled = !health.IsDead();
      UpdateAnimator();
    }

    public void StartMoveAction(Vector3 destination)
    {
      actionScheduler.StartAction(this);
      MoveTo(destination);
    }

    public void MoveTo(Vector3 destination)
    {
      agent.isStopped = false;
      agent.SetDestination(destination);
    }

    public void Cancel()
    {
      agent.isStopped = true;
    }
   



    private void UpdateAnimator()
    {
      Vector3 velocity = agent.velocity;
      Vector3 localVelocity = transform.InverseTransformDirection(velocity);
      float speed = localVelocity.z;
      animator.SetFloat("forwardSpeed", speed);
    }

  }
}
