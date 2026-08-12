using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
   public void startGame(){
    SceneManager.LoadScene("Game");
   }

   public void howToPlay(){
    SceneManager.LoadScene("Tutorial");
   }

   public void back(){
    SceneManager.LoadScene("MainMenu");
   }

   public void quitGame(){
    Application.Quit();
   }
   
}
