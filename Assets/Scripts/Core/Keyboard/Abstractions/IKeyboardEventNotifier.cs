using System;

namespace Core.Keyboard.Abstractions
{
    /// <summary>
    /// ќповещает о действи€х совершенных на клавиатуре.
    /// </summary>
    public interface IKeyboardEventNotifier
    {
        event Action<IKeyboardLayout> KeyboardLayoutChanged;
        event Action<char> SymbolWritten;
        event Action SymbolRemoved;
        event Action<bool> CaseChanged;
        event Action EnterPressed;
    }
}
