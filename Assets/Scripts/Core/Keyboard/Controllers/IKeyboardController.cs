using Core.Keyboard.Abstractions;

namespace Core.Keyboard.Controllers
{
    /// <summary>
    /// Дает доступ к управлению клавиатурой.
    /// </summary>
    public interface IKeyboardController
    {
        void SetKeyboardLayout(IKeyboardLayout keyboardLayout);

        void WriteSymbol(char symbol);

        void RemoveSymbol();

        void SetUpperCase(bool value);

        void PressEnter();
    }
}

