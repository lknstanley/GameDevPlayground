using System.Threading.Tasks;

namespace UINavigationSystem.Core.Interface
{
    public interface IUIEvent
    {
        public Task OnLoad();
        public Task PostLoad();
        public Task OnDisplay();
        public Task PostDisplay();
        public Task OnPop();
    }
}