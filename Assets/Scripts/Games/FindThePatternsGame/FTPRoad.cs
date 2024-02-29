using Games.FindThePatternsGame.Constraints;
using UnityEngine;

namespace Games.FindThePatternsGame
{
    public class FTPRoad : MonoBehaviour
    {
        [ SerializeField ]
        private Vector3 size = Vector3.one;

        [ SerializeField ]
        private Vector3 pos = Vector3.zero;

        [ SerializeField ]
        private FTPRoadType roadType;

        public void Initialise( Vector3 pos, Vector3 size, FTPRoadType type )
        {
            var trans = transform;
            trans.localScale = size;
            trans.localPosition = pos;
            roadType = type;
        }

        public Vector3 GetSize()
        {
            return size;
        }

        public FTPRoadType GetRoadType()
        {
            return roadType;
        }

        public void ChangeColor( Color newColor )
        {
            GetComponent< Renderer >().material.color = newColor;
        }
    }
}