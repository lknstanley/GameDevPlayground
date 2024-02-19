using System.Threading.Tasks;
using UnityEngine;

namespace Games.FindThePatternsGame.Managers
{
    public class FTPUIManager : MonoBehaviour, IManagerEvent< FTPUIManager >
    {
        public FTPUIManager GetInstance()
        {
            return this;
        }

        public async Task LoadAsset()
        {
            Debug.Log( $"[{gameObject.name}] Start Preparing Assets" );
            await Task.Delay( 1000 );
        }
    }
}