using UnityEngine;

namespace MatchPictures.Global.Currency
{
    public class CurrencyData : MonoBehaviour
    {
        public static CurrencyData currencyInstance;
        private const string _prefsKey = "CurrencyData";

        [SerializeField] private int _gold;
        [SerializeField] private int _addingGold = 100;

        public int gold => _gold;

        private void Awake()
        {
            if (currencyInstance == null)
            {
                currencyInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            Load();
        }

        public void AddGold()
        {
            _gold += _addingGold;
            Save();
        }

        public void SpendGold(int price)
        {
            _gold -= price;
            Save();
        }

        private void Save()
        {
            string json = JsonUtility.ToJson(this);
            PlayerPrefs.SetString(_prefsKey, json);
            Debug.Log(json);
        }

        private void Load()
        {
            if (PlayerPrefs.HasKey(_prefsKey))
            {
                string json = PlayerPrefs.GetString(_prefsKey);
                JsonUtility.FromJsonOverwrite(json, this);
            }
            else
            {
                Save();
            }
        }
    }
}

