using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MR
{
    public class SceneUtility : MonoBehaviour
    {
    private static SceneUtility instance;

   
    private void Awake()
    {
      GetInstance();
    }

    void Update()
    {
      TickInput();
    }

    private void TickInput(){
      HandleRInput();
    }

    private void HandleRInput(){
      // Перевіряємо, чи була натиснута клавіша "R"
      if (Input.GetKeyDown(KeyCode.R))
      {
        ReloadScene();
        Debug.Log("Сцена перезавантажена!");
      }
    }

    private void ReloadScene()
    {
      // Отримуємо індекс поточної активної сцени
      int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

      // Перезавантажуємо сцену за її індексом
      SceneManager.LoadScene(currentSceneIndex);
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
