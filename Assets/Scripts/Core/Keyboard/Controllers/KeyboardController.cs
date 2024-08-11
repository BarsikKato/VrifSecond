using Core.Keyboard.Abstractions;
using System;

namespace Core.Keyboard.Controllers
{
    public sealed class KeyboardController : IKeyboardController
    {
        public event Action<IKeyboardLayout> KeyboardLayoutChanged;
        public event Action<char> SymbolWritten;

        private IKeyboardLayout _currentLayout;

        public void SetKeyboardLayout(IKeyboardLayout keyboardLayout)
        {
            if (keyboardLayout == _currentLayout)
            {
                return;
            }

            _currentLayout = keyboardLayout;
            KeyboardLayoutChanged?.Invoke(_currentLayout);
        }

        public void WriteSymbol(char symbol)
        {
            SymbolWritten?.Invoke(symbol);
        }
    }
}

