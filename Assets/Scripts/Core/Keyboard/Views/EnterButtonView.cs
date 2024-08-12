using Core.Keyboard.Controllers;
using Core.UI;
using Zenject;

namespace Core.Keyboard.Views
{
    /// <summary>
    /// ������ Enter ����������.
    /// </summary>
    public sealed class EnterButtonView : ButtonView
    {
        [Inject] private readonly IKeyboardController _keyboardController;

        protected override void OnClick()
        {
            _keyboardController.PressEnter();
        }
    }
}

