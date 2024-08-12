using Core.Keyboard.Controllers;
using Core.UI;
using Zenject;

namespace Core.Keyboard.Views
{
    public sealed class RemoveSymbolButtonVIew : ButtonView
    {
        [Inject] private readonly IKeyboardController _keyboardController;

        protected override void OnClick()
        {
            _keyboardController.RemoveSymbol();
        }
    }
}
