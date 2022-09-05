using MatchPictures.Global;
using MatchPictures.Global.Save;
using MatchPictures.Message;
using MatchPictures.Scene.Gameplay.InputRaycasts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

namespace MatchPictures.Scene.Gameplay.TileObjects
{
    public class TileObject : MonoBehaviour, IRaycastable
    {
        public delegate void TileClicked(int x, int y);
        public static event TileClicked OnTileClicked;

        private int _indexX;
        private int _indexY;
        private int _indexType;
        [SerializeField] private string[] _themes;
        [SerializeField] private Sprite[] _sprites;

        private string _currentTheme;

        public int indexX => _indexX;
        public int indexY => _indexY;
        public int indexType => _indexType;

        private void Awake()
        {
            _currentTheme = _themes[SaveData.saveInstance.currentTheme];
            _sprites = Resources.LoadAll<Sprite>("Image/" + _currentTheme);
        }

        public void SetAllIndex(int X, int Y, int Type)
        {
            _indexX = X;
            _indexY = Y;
            _indexType = Type;
            SetImage(_indexType);
        }

        public void SetImage(int Type)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _sprites[Type];
        }

        public void OnRaycasted()
        {
            OnTileClicked(_indexX, _indexY);
            //EventManager.TriggerEvent("TileClicked", new TileClickedMessage(_indexX, _indexY));
        }
    }
}
