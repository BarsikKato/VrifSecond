using Core.Keyboard.Abstractions;
using System;

namespace Core.Keyboard.Controllers
{
    public sealed class KeyboardController : IKeyboardController
    {
        public event Action<IKeyboardLayout> KeyboardLayoutChanged;
        public event Action<char> SymbolWritten;
        public event Action SymbolRemoved;
        public event Action<bool> CaseChanged;
        public event Action EnterPressed;

        private IKeyboardLayout _currentLayout;
        private bool _isUpperCase;

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

        public void SetUpperCase(bool value)
        {
            if (_isUpperCase != value)
            {
                _isUpperCase = value;
                CaseChanged?.Invoke(value);
            }
        }

        public void RemoveSymbol()
        {
            SymbolRemoved?.Invoke();
        }

        public void PressEnter()
        {
            EnterPressed?.Invoke();
        }
    }
}

