using MatchPictures.Global.Currency;
using TMPro;
using UnityEngine;

namespace MatchPictures.Scene.Theme.ThemeScene
{
    public class DisplayGold : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _goldText;

        private void Update()
        {
            _goldText.text = CurrencyData.currencyInstance.gold.ToString() + "G";
        }
    }
}

