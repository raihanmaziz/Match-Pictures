using UnityEngine;

namespace MatchPictures.Global.Theme
{
    public class ThemeDatabase : MonoBehaviour
    {
        public static ThemeDatabase themeInstance;
        private const string _prefsKey = "ThemeDatabase";

        private void Awake()
        {
            if (themeInstance == null)
            {
                themeInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            Load();
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

