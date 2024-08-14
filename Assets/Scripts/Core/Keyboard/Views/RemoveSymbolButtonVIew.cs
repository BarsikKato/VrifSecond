using Core.Keyboard.Controllers;
using Core.UI;
using Zenject;

namespace Core.Keyboard.Views
{
    /// <summary>
    /// ������ �������� �������.
    /// </summary>
    public sealed class RemoveSymbolButtonView : ButtonView
    {
        [Inject] private readonly IKeyboardController _keyboardController;

        protected override void OnClick()
        {
            _keyboardController.RemoveSymbol();
        }
    }
}
