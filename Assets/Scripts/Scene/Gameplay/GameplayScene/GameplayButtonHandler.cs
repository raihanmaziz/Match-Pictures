using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MatchPictures.Scene.Gameplay.GameplayScene
{
    public class GameplayButtonHandler : MonoBehaviour
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

