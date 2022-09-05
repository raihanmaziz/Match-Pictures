using MatchPictures.Global.Currency;
using UnityEngine;

namespace MatchPictures.Global.Save
{
    public class SaveData : MonoBehaviour
    {
        public static SaveData saveInstance;
        private const string _prefsKey = "SaveData";

        [SerializeField] private int _currentTheme;
        [SerializeField] private bool[] _boughtTheme;

        public int currentTheme => _currentTheme;
        public bool[] boughtTheme => _boughtTheme;

        private void Awake()
        {
            if (saveInstance == null)
            {
                saveInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            Load();
        }

        public void ChangeCurrentTheme(int theme)
        {
            if (_boughtTheme[theme])
            {
                _currentTheme = theme;
            }
            else
            {
                int cost = (theme - 1) * 100;
                if (CurrencyData.currencyInstance.gold >= cost)
                {
                    _boughtTheme[theme] = true;
                    CurrencyData.currencyInstance.SpendGold(cost);
                }
            }
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

