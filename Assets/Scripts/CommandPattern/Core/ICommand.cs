using System;

namespace CommandPattern.Core
{
    public interface ICommand : IDisposable
    {
        public void Execute();
        public void Undo();
    }
}