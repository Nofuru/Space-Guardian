using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoadScenes
{
    public class MainMenuLoad : MonoBehaviour
    {
        private const int MainMenuScene = 0;
        public void MenuSceneLoader()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(MainMenuScene);
        }
    }
}
