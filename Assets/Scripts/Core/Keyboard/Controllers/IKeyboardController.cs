using Core.Keyboard.Abstractions;
using System;

namespace Core.Keyboard.Controllers
{
    public interface IKeyboardController
    {
        void SetKeyboardLayout(IKeyboardLayout keyboardLayout);

        void WriteSymbol(char symbol);

        void RemoveSymbol();

        void SetUpperCase(bool value);

        void PressEnter();
    }
}

