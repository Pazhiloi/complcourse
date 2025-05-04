using UnityEngine;
using UnityEngine.AI;
namespace RPG.Movement
{

  public class Mover : MonoBehaviour
  {
    [SerializeField] private Transform target;
    private NavMeshAgent agent;
    private Animator animator;

    private void Awake()
    {
      agent = GetComponent<NavMeshAgent>();
      animator = GetComponent<Animator>();
    }

    void Update()
    {
      UpdateAnimator();
    }

    public void MoveTo(Vector3 destination)
    {
      agent.isStopped = false;
      agent.SetDestination(destination);
    }

    public void Stop()
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
