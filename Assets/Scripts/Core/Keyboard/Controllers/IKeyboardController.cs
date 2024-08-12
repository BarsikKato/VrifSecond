using Core.Keyboard.Abstractions;
using System;

namespace Core.Keyboard.Controllers
{
    public interface IKeyboardController
    {
        event Action<IKeyboardLayout> KeyboardLayoutChanged;
        event Action<char> SymbolWritten;
        event Action SymbolRemoved;
        event Action<bool> CaseChanged;
        event Action EnterPressed;

        void SetKeyboardLayout(IKeyboardLayout keyboardLayout);

        void WriteSymbol(char symbol);

        void RemoveSymbol();

        void SetUpperCase(bool value);

        void PressEnter();
    }
}

