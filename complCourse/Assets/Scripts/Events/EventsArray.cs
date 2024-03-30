using UnityEngine;
using UnityEngine.Events;

public class EventsArray : MonoBehaviour
{
   public UnityEvent[] Events;

   public void StartEvent(int eventIndex){
    Events[eventIndex].Invoke();
   }
}
