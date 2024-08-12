using Core.Keyboard.Controllers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.InputScreen.Views
{
    [RequireComponent(typeof(InputField))]
    public sealed class InputScreenView : MonoBehaviour
    {
        [Inject] private readonly IKeyboardController _keyboardController;

        private InputField _inputField;

        private void Awake()
        {
            _keyboardController.SymbolWritten += KeyboardController_SymbolWritten;
            _keyboardController.SymbolRemoved += KeyboardController_SymbolRemoved;
            _keyboardController.EnterPressed += KeyboardController_EnterPressed;
        }

        private void Start()
        {
            _inputField = GetComponent<InputField>();
        }

        private void OnDestroy()
        {
            _keyboardController.SymbolWritten -= KeyboardController_SymbolWritten;
            _keyboardController.SymbolRemoved -= KeyboardController_SymbolRemoved;
            _keyboardController.EnterPressed -= KeyboardController_EnterPressed;
        }

        private void KeyboardController_SymbolWritten(char symbol)
        {
            _inputField.text += symbol;
        }

        private void KeyboardController_SymbolRemoved()
        {
            if (_inputField.text.Length == 0)
                return;

            _inputField.text = _inputField.text.Remove(_inputField.text.Length - 1);
        }

        private void KeyboardController_EnterPressed()
        {
            _inputField.text += '\n';
        }
    }
}