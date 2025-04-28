using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MR
{
    public class Destroyer : MonoBehaviour
    {
    public float delayInSeconds = 5f; // Час в секундах до знищення

    void Start()
    {
      // Запускаємо таймер на знищення об'єкта
      Destroy(gameObject, delayInSeconds);
    }

  }
}
