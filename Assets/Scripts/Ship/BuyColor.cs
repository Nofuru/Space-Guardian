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
            if (PlayerPrefs.HasKey("ButtonText") && ColorKeeper.purchasedColors.Contains(color))
            {
                text.text = PlayerPrefs.GetString("ButtonText");
            }

            if (PlayerPrefs.HasKey("IsPurchased") && ColorKeeper.purchasedColors.Contains(color))
            {
                _isPurchased = PlayerPrefs.GetInt("IsPurchased");
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
            PlayerPrefs.SetInt("IsPurchased", _isPurchased);
            PlayerPrefs.SetString("ButtonText", text.text);
            
            PlayerPrefs.Save();
        }

    }
}
