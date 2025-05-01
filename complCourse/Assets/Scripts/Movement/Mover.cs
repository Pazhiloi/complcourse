using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
  [SerializeField] private Transform target;
  private NavMeshAgent agent;

  private void Awake()
  {
    agent = GetComponent<NavMeshAgent>();
  }
  
  void Update()
  {
    if (Input.GetMouseButton(0))
    {
      MoveToCursor();
    }
  }

  private void MoveToCursor(){
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;
    bool hasHit = Physics.Raycast(ray, out hit);

    if (hasHit)
    {
      agent.SetDestination(hit.point);
    }
    
  }

  
}
