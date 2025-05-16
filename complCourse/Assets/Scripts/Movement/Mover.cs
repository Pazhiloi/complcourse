using RPG.Core;
using UnityEngine;
using UnityEngine.AI;
namespace RPG.Movement
{

  public class Mover : MonoBehaviour, IAction
  {
    [SerializeField] private Transform target;
    [SerializeField] private float maxSpeed = 6f;
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

    public void StartMoveAction(Vector3 destination, float speedFraction)
    {
      actionScheduler.StartAction(this);
      MoveTo(destination, speedFraction);
    }

    public void MoveTo(Vector3 destination, float speedFraction)
    {
      agent.isStopped = false;
      agent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
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
