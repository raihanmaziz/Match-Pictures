using UnityEngine;

namespace MatchPictures.Message
{
    public struct TileClickedMessage
    {
        public int x { get; }
        public int y { get; }

        public TileClickedMessage(int X, int Y)
        {
            x = X;
            y = Y;
        }
    }
}

