using UnityEngine;
using UnityEngine.SceneManagement;

namespace LoadScenes
{
    public class GameLoad : MonoBehaviour
    {
        private const int GameScene = 1;

        public void GameSceneLoader()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(GameScene);
        }
    }
}
