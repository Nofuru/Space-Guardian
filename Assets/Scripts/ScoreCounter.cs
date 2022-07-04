using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter instance;
    
    [SerializeField] private Text currentScore;
    [SerializeField] private Text highScore;
    
    private readonly WaitForSeconds _waitBetweenPoints = new WaitForSeconds(0.01f);
    private float _score = 0;
    private float _highscore;

    public void AnnulScoreForQuit()
    {
        PlayerPrefs.SetFloat("HighScore", 0);
    }
    
    private void Awake()
    {
        instance = this;
    }
    
    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            _highscore = PlayerPrefs.GetFloat("HighScore");
        }
        
        StartCoroutine(ScoreCount());
    }

    public void AddPoints(float points)
    {
        _score += points;
    }

    private IEnumerator ScoreCount()
    {
        for (;;)
        {
            _score += 20 * Time.deltaTime;

            if (_score > _highscore)
            {
                _highscore = _score;
            }

            currentScore.text = _score.ToString("0");
            highScore.text = _highscore.ToString("0");
            SaveScoreInformation();
            yield return _waitBetweenPoints;
        }
    }
    
    private void OnDisable()
    {
        StopCoroutine(ScoreCount());
    }

    private void SaveScoreInformation()
    {
        PlayerPrefs.SetFloat("HighScore", _highscore);
        PlayerPrefs.SetFloat("Score", _score);
        PlayerPrefs.Save();
    }
}
