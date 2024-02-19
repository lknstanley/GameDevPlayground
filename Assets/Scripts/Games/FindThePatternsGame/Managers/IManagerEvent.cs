using System.Threading.Tasks;

namespace Games.FindThePatternsGame.Managers
{
    public interface IManagerEvent< out T >
    {
        public T GetInstance();
        public Task LoadAsset();
    }
}