using UnityEngine;
namespace BM1
{

  public class WaveManager : MonoBehaviour
  {
    public static WaveManager instance;
    public float amplitude = 1f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;

    private void Awake()
    {
      GetInstance();
    }



    private void Update()
    {
      offset += Time.deltaTime * speed;
    }

    public float GetWaveHeight(float x)
    {
      return amplitude * Mathf.Sin(x / length + offset);
    }













    private void GetInstance()
    {
      if (instance == null)
      {
        instance = this;
      }
      else if (instance != this)
      {
        Debug.Log("Duplicate instance of WaveManager found. Destroying the new instance.");
        Destroy(gameObject);
      }
    }
  }
}
