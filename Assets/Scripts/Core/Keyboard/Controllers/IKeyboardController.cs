using Core.Keyboard.Abstractions;

namespace Core.Keyboard.Controllers
{
    /// <summary>
    /// ���� ������ � ���������� �����������.
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

