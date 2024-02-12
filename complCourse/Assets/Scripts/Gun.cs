using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
  public GameObject bulletPrefab;
  public float bulletSpeed;
  public AudioSource ShotSound;

  public float ShotPeriod = 0.15f;

  private float _timer = 0;

  private void Update()
  {

    _timer += Time.deltaTime;
    if (Input.GetKey(KeyCode.Space))
    {
      if (_timer > ShotPeriod)
      {
        _timer = 0f;
        CreateBullet();
      }
    }
  }


  private void CreateBullet()
  {
    GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    newBullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    ShotSound.pitch = Random.Range(0.8f, 1.2f);
    ShotSound.Play();
  }

}
