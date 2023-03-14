using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int currentScene = 0;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }
   public void PauseGame()
   {
        Time.timeScale = 0;
   }
   public void ResumeGame()
   {
        Time.timeScale = 1;
   }
   public void RestartGame()
   {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
   }
   public void Replay()
   {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene);
   }
   public void NextLevel()
   {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentScene += 1);
   }
   public void QuitLevel()
   {
        //If we are running in the editor
        #if UNITY_EDITOR
            //Stop playing the scene
            UnityEditor.EditorApplication.isPlaying = false;

        //If we are running in a standalone build of the game
        #elif UNITY_STANDALONE || UNITY_WEBGL
            //Quit the application
            Application.Quit();

        #else
            Application.Quit();
        #endif
   }
}
