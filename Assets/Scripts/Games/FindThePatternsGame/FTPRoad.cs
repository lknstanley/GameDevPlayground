using UnityEngine;

namespace Games.FindThePatternsGame
{
    public class FTPRoad : MonoBehaviour
    {
        [ SerializeField ]
        private Vector3 size = Vector3.one;

        [ SerializeField ]
        private Vector3 pos = Vector3.zero;

        public void Initialise( Vector3 pos, Vector3 size )
        {
            var trans = transform;
            trans.localScale = size;
            trans.localPosition = pos;
        }

        public Vector3 GetSize()
        {
            return size;
        }
    }
}