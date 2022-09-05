using UnityEngine;
using MatchPictures.Scene.Gameplay.TileObjects;
using MatchPictures.Global;
using MatchPictures.Message;

namespace MatchPictures.Scene.Gameplay.TileGroups
{
    public class TileGroup : MonoBehaviour
    {
        public int column { get; private set; } = 5;
        public int row { get; private set; } = 6;
        public TileObject[,] tileList { get; private set; }

        [SerializeField] private TileObject _tilePrefab;

        private int _tileCount = 0;
        private int _lastX = -1;
        private int _lastY = -1;
        private int _lastType = -1;

        private void Awake()
        {
            if (row*column %2 != 0)
            {
                row++;
            }
            SpawnTile();
        }

        private void OnEnable()
        {
            EventManager.StartListening("TileClicked", TryMatchClickedTiles);
        }

        private void OnDisable()
        {
            EventManager.StopListening("TileClicked", TryMatchClickedTiles);
        }

        private void SpawnTile()
        {
            tileList = new TileObject[column, row];
            for (int x = 0; x < column; x++)
            {
                for (int y = 0; y < row; y++)
                {
                    Vector2 spawnPosition = new Vector2(x, y);
                    TileObject tileObjects = Instantiate(_tilePrefab, spawnPosition, Quaternion.identity, transform);

                    tileList[x, y] = tileObjects;
                    
                    tileObjects.gameObject.name = "Tile( " + ("X:" + x + " ,Z:" + y + " )");
                    tileObjects.SetAllIndex(x, y, Random.Range(0, tileObjects.typeLength));
                    _tileCount++;
                }
            }
        }

        private void TryMatchClickedTiles(object Message)
        {
            TileClickedMessage message = (TileClickedMessage)Message;
            int x = message.x;
            int y = message.y;
            if (_lastType == -1)
            {
                _lastX = x;
                _lastY = y;
                _lastType = tileList[x, y].indexType;
            }
            else
            {
                if (_lastType == tileList[x, y].indexType)
                {
                    DespawnTile(x, y);
                }
                _lastType = -1;
            }
        }

        private void DespawnTile(int X, int Y)
        {
            tileList[X, Y].gameObject.SetActive(false);
            tileList[_lastX, _lastY].gameObject.SetActive(false);
            _tileCount -= 2;
            if (_tileCount == 0)
            {
                EventManager.TriggerEvent("TilesCleared", true);
            }
        }
    }
}

