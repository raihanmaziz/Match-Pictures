using MatchPictures.Global;
using MatchPictures.Global.Currency;
using MatchPictures.Scene.Gameplay.GameTimers;
using MatchPictures.Scene.Gameplay.TileGroups;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MatchPictures.Scene.Gameplay.GameFlow
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _losePanel;
        [SerializeField] private Button _backButton;

        private void Awake()
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(OpenHome);
        }

        private void OnEnable()
        {
            GameTimer.OnTimeOver += SetGameOverState;
            TileGroup.OnTilesCleared += SetGameOverState;
            //EventManager.StartListening("TilesCleared", SetGameOverState);
            //EventManager.StartListening("TimeOver", SetGameOverState);
        }

        private void OnDisable()
        {
            GameTimer.OnTimeOver -= SetGameOverState;
            TileGroup.OnTilesCleared -= SetGameOverState;
            //EventManager.StopListening("TilesCleared", SetGameOverState);
            //EventManager.StopListening("TimeOver", SetGameOverState);
        }

        private void SetGameOverState(bool isWin)
        {
            _gameOverPanel.SetActive(true);
            if (isWin)
            {
                _winPanel.SetActive(true);
                CurrencyData.currencyInstance.AddGold();
            }
            else
            {
                _losePanel.SetActive(true);
            }
        }

        //private void SetGameOverState(object data)
        //{
        //    bool isWin = (bool)data;
        //    _gameOverPanel.SetActive(true);
        //    if (isWin)
        //    {
        //        _winPanel.SetActive(true);
        //        CurrencyData.currencyInstance.AddGold();
        //    }
        //    else
        //    {
        //        _losePanel.SetActive(true);
        //    }
        //}

        private void OpenHome()
        {
            SceneManager.LoadScene("HomeScene");
        }
    }
}

