using UnityEngine;
using UnityEngine.UI;

namespace Ship
{
    public class BuyColor : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private int color;
        [SerializeField] private int price;
        
        private Wallet _wallet;
        private int _isPurchased = 0;

        private void Start()
        {
            if (PlayerPrefs.HasKey("ButtonText" + color))
            {
                text.text = PlayerPrefs.GetString("ButtonText" + color);
            }

            if (PlayerPrefs.HasKey("IsPurchased" + color))
            {
                _isPurchased = PlayerPrefs.GetInt("IsPurchased" + color);
            }
        }

        private void SetColor()
        {
            _wallet = Wallet.instance;

            if (_isPurchased == 1)
            {
                ColorKeeper.savedColor = color;
            }
            
            if (_wallet.GetMoneyAmount() >= price && _isPurchased == 0)
            {
                Purchase();

                ColorKeeper.savedColor = color;
                _wallet.TakeMoney(price);
                _wallet.ShowOnScreen();
            }
        }

        private void Purchase()
        {
            text.text = "Purchased";
            _isPurchased = 1;
            
            SavePurchaseInformation();
        }

        private void SavePurchaseInformation()
        {
            PlayerPrefs.SetInt("SavedColor", color);
            PlayerPrefs.SetInt("IsPurchased" + color, _isPurchased);
            PlayerPrefs.SetString("ButtonText" + color, text.text);
            
            PlayerPrefs.Save();
        }

    }
}
