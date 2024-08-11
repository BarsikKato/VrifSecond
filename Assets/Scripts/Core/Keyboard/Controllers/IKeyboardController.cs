using Core.Keyboard.Abstractions;
using System;

namespace Core.Keyboard.Controllers
{
    public interface IKeyboardController
    {
        event Action<IKeyboardLayout> KeyboardLayoutChanged;
        event Action<char> SymbolWritten;

        void SetKeyboardLayout(IKeyboardLayout keyboardLayout);

        void WriteSymbol(char symbol);
    }
}

