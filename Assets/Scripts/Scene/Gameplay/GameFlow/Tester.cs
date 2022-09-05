using MatchPictures.Global;
using UnityEngine;

namespace MatchPictures.Scene.Gameplay.GameFlow
{
    public class Tester : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                EventManager.TriggerEvent("TilesCleared", true);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                EventManager.TriggerEvent("TimeOver", false);
            }
            Debug.Log("go");
        }
    }
}

