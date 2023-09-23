using UnityEngine;
using UnityEngine.SceneManagement;

namespace Manager
{
    public class ButtonManger : MonoBehaviour
    {
        public void NewGame()
        {
            Music.Instance.SetVolume(0.05f);
            GameManager.Instance.ResetFields();
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
            Music.Instance.SetVolume(1f);
            SceneManager.LoadScene("Menu");
        }

        public void RestartGame()
        {
            GameManager.Instance.ResetFields();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void OpenMenu(GameObject menu)
        {
            menu.SetActive(true);
        }

        public void CloseMenu(GameObject menu)
        {
            menu.SetActive(false);
        }
    }
}
