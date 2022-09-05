using MatchPictures.Global;
using UnityEngine;

namespace MatchPictures.Scene.Gameplay.GameFlow
{
    public class GameFlow : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _winPanel;
        [SerializeField] private GameObject _losePanel;

        private void OnEnable()
        {
            EventManager.StartListening("TilesCleared", SetGameOverState);
            EventManager.StartListening("TimeOver", SetGameOverState);
        }

        private void OnDisable()
        {
            EventManager.StopListening("TilesCleared", SetGameOverState);
            EventManager.StopListening("TimeOver", SetGameOverState);
        }

        private void SetGameOverState(object data)
        {
            bool isWin = (bool)data;
            _gameOverPanel.SetActive(true);
            if (isWin)
            {
                _winPanel.SetActive(true);
            }
            else
            {
                _losePanel.SetActive(true);
            }
        }
    }
}

