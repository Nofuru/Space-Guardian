using System.Collections.Generic;
using UnityEngine;

public class ColorKeeper : MonoBehaviour
{
    public static int savedColor = 0;
    public static List<int> purchasedColors = new List<int>();

    private void Awake()
    {
        savedColor = PlayerPrefs.GetInt("SavedColor");
        SavePurchasedColors();
    }

    private void SavePurchasedColors()
    {
        if (!purchasedColors.Contains(savedColor) && savedColor != 0)
        {
            purchasedColors.Add(savedColor);
        }
    }
}
