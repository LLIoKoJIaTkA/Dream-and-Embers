using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
   public void gameStart()
   {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void exitGame()
   {
        Debug.Log("Ждем вас снова");
        Application.Quit();
   }
}
