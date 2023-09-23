using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class ButtonManger : MonoBehaviour
    {
        public void NewGame(){
            SceneManager.LoadScene("RubyFactory");
        }

        public void LoadSetting()
        {
            SceneManager.LoadScene("Setting");
        }
        public void Quit()
        {
            Application.Quit();
        }

        public void LoadMenu()
        {
            SceneManager.LoadScene("Menu");
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
