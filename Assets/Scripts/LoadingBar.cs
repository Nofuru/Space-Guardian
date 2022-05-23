using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public GameObject loadingMenu;
    public Slider slider;
    
    public void Start()
    {
        SceneManager.LoadScene(1);
        StartCoroutine(LoadAsynchronously());
    }

    private IEnumerator LoadAsynchronously()
    {
        var operation = SceneManager.LoadSceneAsync(0);

        loadingMenu.SetActive(true);
        
        while (!operation.isDone)
        {
            var progress = Mathf.Clamp01(operation.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }
}
