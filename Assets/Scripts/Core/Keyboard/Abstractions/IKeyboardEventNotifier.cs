using System;

namespace Core.Keyboard.Abstractions
{
    public interface IKeyboardEventNotifier
    {
        event Action<IKeyboardLayout> KeyboardLayoutChanged;
        event Action<char> SymbolWritten;
        event Action SymbolRemoved;
        event Action<bool> CaseChanged;
        event Action EnterPressed;
    }
}
