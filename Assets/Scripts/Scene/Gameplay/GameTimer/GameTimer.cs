using MatchPictures.Global;
using TMPro;
using UnityEngine;

namespace MatchPictures.Scene.Gameplay.GameTimers
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private float _timeLeft = 30f;

        private void Update()
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimer(_timeLeft);
            }
            else
            {
                _timeLeft = 0;
                EventManager.TriggerEvent("TimeOver", false);
            }
        }

        private void UpdateTimer(float timeUpdate)
        {
            timeUpdate += 1;
            float seconds = Mathf.FloorToInt(timeUpdate % 60);

            _timerText.text = seconds.ToString() + "s";
        }
    }
}

