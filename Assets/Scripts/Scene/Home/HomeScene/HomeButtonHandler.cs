using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MatchPictures.Scene.Home.HomeScene
{
    public class HomeButtonHandler : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _themeButton;

        private void Awake()
        {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(OpenGameplay);
            _themeButton.onClick.RemoveAllListeners();
            _themeButton.onClick.AddListener(OpenTheme);
        }

        private void OpenGameplay()
        {
            SceneManager.LoadScene("GameplayScene");
        }

        private void OpenTheme()
        {
            SceneManager.LoadScene("ThemeScene");
        }
    }

}

