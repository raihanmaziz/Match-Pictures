using MatchPictures.Global;
using MatchPictures.Message;
using MatchPictures.Scene.Gameplay.InputRaycasts;
using System.Collections.Generic;
using UnityEngine;

namespace MatchPictures.Scene.Gameplay.TileObjects
{
    public class TileObject : MonoBehaviour, IRaycastable
    {
        private int _indexX;
        private int _indexY;
        private int _indexType;
        private int _typeLength;
        private List<Color> _tileColor = new List<Color>();
        private string _theme;
        [SerializeField] private Sprite[] _sprites;

        public int indexX => _indexX;
        public int indexY => _indexY;
        public int indexType => _indexType;
        public int typeLength => _typeLength;

        private void Awake()
        {
            _theme = "fruit";
            _tileColor.Add(Color.white);
            _tileColor.Add(Color.black);
            _tileColor.Add(Color.green);
            _typeLength = _tileColor.Count;
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
            //gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/" + _theme);
            gameObject.GetComponent<Renderer>().material.color = _tileColor[Type];
        }

        public void OnRaycasted()
        {
            EventManager.TriggerEvent("TileClicked", new TileClickedMessage(_indexX, _indexY));
        }
    }
}
