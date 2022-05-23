using Shooting;
using UnityEngine.UI;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public static Wallet instance;
    
    [HideInInspector] public float defaultEnemyPrice = 500;
    [HideInInspector] public float defaultEnemyPricePerRam = 1500;
    [HideInInspector] public int defaultEnemyValue = 1;

    [SerializeField] private Text currentMoney;

    private float _amount = 0;
    private int _defaultEnemyKillCounter;

    public float GetMoneyAmount()
    {
        return _amount;
    }

    public void TakeMoney(float money)
    {
        _amount -= money; 
        SaveMoneyAmount();

    }
    
    public void TakeMoneyForQuit()
    {
        if (_defaultEnemyKillCounter * defaultEnemyPrice < _amount)
        {
            _amount -= _defaultEnemyKillCounter * defaultEnemyPrice;
            SaveMoneyAmount();
        }
    }
    
    public void AddMoney(float money)
    {
        _amount += money;
        SaveMoneyAmount();
    }

    public void AddKillPoint(int point)
    {
        _defaultEnemyKillCounter += point;
    }

    public void ShowOnScreen()
    {
        currentMoney.text = _amount.ToString("0");
        currentMoney.text += " $";
    }

    public void CheckForBulletUpgrade()
    {
        if (_defaultEnemyKillCounter % 15 == 0)
        {
            BulletUpgrade.Upgrade();
        }
    }
    
    private void SaveMoneyAmount()
    {
        PlayerPrefs.SetFloat("Amount", _amount);
        PlayerPrefs.Save();
    }

    private void LoadSavedMoney()
    {
        if (PlayerPrefs.HasKey("Amount"))
        {
            _amount = PlayerPrefs.GetFloat("Amount");
        }
    }
    
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        transform.position = new Vector3(0,0,0);
        LoadSavedMoney();
        ShowOnScreen();
    }
}
