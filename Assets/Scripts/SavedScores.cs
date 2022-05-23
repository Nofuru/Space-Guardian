using UnityEngine.UI;
using UnityEngine;

public class SavedScores : MonoBehaviour
{
    [SerializeField] private Text lastScore;
    [SerializeField] private Text highScore;
    
    private void Start()
    {
        lastScore.text = PlayerPrefs.GetFloat("Score").ToString("0");
        highScore.text = PlayerPrefs.GetFloat("HighScore").ToString("0");
    }
}
