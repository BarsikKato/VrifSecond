using Core.Keyboard.Abstractions;
using Core.Keyboard.Controllers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.InputScreen.Views
{
    [RequireComponent(typeof(InputField))]
    public sealed class InputScreenView : MonoBehaviour
    {
        [Inject] private readonly IKeyboardEventNotifier _keyboardEventNotifier;

        private InputField _inputField;

        private void Awake()
        {
            _keyboardEventNotifier.SymbolWritten += KeyboardEventNotifier_SymbolWritten;
            _keyboardEventNotifier.SymbolRemoved += KeyboardEventNotifier_SymbolRemoved;
            _keyboardEventNotifier.EnterPressed += KeyboardEventNotifier_EnterPressed;
        }

        private void Start()
        {
            _inputField = GetComponent<InputField>();
        }

        private void OnDestroy()
        {
            _keyboardEventNotifier.SymbolWritten -= KeyboardEventNotifier_SymbolWritten;
            _keyboardEventNotifier.SymbolRemoved -= KeyboardEventNotifier_SymbolRemoved;
            _keyboardEventNotifier.EnterPressed -= KeyboardEventNotifier_EnterPressed;
        }

        private void KeyboardEventNotifier_SymbolWritten(char symbol)
        {
            _inputField.text += symbol;
        }

        private void KeyboardEventNotifier_SymbolRemoved()
        {
            if (_inputField.text.Length == 0)
                return;

            _inputField.text = _inputField.text.Remove(_inputField.text.Length - 1);
        }

        private void KeyboardEventNotifier_EnterPressed()
        {
            _inputField.text += '\n';
        }
    }
}