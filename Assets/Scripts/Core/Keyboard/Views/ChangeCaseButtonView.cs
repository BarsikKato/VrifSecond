using Core.Keyboard.Controllers;
using Core.UI;
using Zenject;

namespace Core.Keyboard.Views
{
    public sealed class ChangeCaseButtonView : ButtonView
    {
        [Inject] private readonly IKeyboardController _keyboardController;

        private bool _isUpperCase = false;

        protected override void OnClick()
        {
            _isUpperCase = !_isUpperCase;
            _keyboardController.SetUpperCase(_isUpperCase);
        }
    }
}