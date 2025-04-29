using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MR
{
    public class CannonShooting : MonoBehaviour
    {
    
    public GameObject cannonBall;
    public bool isSelf = false;

    
    public Transform muzzle;

    [SerializeField, Min(1)]
    public float cannonBallMass = 30;

    [SerializeField, Min(1)]
    private float shotForce = 30;

    
    public float shootDelay = 1;
    public bool isWaiting = false;
    public bool isAiming = false;
    public TrajectoryLine trajectoryLine;

    public UnityEvent OnShoot;
    void Update()
    {
      HandleAiming();
    }

    public void HandleShooting()
    {
      GameObject ball = Instantiate(cannonBall);
      ball.transform.position = muzzle.position;
      OnShoot?.Invoke();
      Rigidbody rb = ball.GetComponent<Rigidbody>();
      rb.mass = cannonBallMass;
      rb.AddForce(muzzle.forward * shotForce, ForceMode.Impulse);
      isWaiting = true;
      StartCoroutine(DelayShooting());
    }

    private void HandleAiming(){
      if (isSelf){
      if (Input.GetMouseButtonDown(1))
      {
        isAiming = !isAiming;
        trajectoryLine.lineRenderer.enabled = isAiming;
      }

      if (isAiming)
      {
        trajectoryLine.ShowTrajectoryline(muzzle.position, muzzle.forward * shotForce / cannonBallMass);
      }

      // Перевіряємо натискання пробілу лише коли прицілювання активне
      if (isAiming && Input.GetKeyDown(KeyCode.Space) && !isWaiting)
      {
        HandleShooting();
      }
      }
    }

    private IEnumerator DelayShooting()
    {
      yield return new WaitForSeconds(shootDelay);
      isWaiting = false;
    }

  }
}
