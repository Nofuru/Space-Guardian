using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoadScenes
{
    public class LoadGameOverScene : MonoBehaviour
    {
        private const int GameOverScene = 2;
    
        public static void GameOverLoader()
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene(GameOverScene);
        }
    }
}
