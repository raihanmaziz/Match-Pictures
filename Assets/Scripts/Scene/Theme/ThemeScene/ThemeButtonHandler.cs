using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MatchPictures.Scene.Theme.ThemeScene
{
    public class ThemeButtonHandler : MonoBehaviour
    {
        [SerializeField] Button _backButton;

        private void Awake()
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(OpenHome);
        }

        private void OpenHome()
        {
            SceneManager.LoadScene("HomeScene");
        }
    }
}

