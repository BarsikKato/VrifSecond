using Core.Keyboard.Abstractions;
using Core.Keyboard.Controllers;
using Core.UI;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Keyboard.Views
{
    /// <summary>
    /// Кнопка ввода символа на клавиатуре.
    /// </summary>
    public sealed class SymbolKeyButtonView : ButtonView
    {
        [SerializeField] private char symbol;
        [SerializeField] private Text buttonLabel;

        [Inject] private readonly IKeyboardController _keyboardController;
        [Inject] private readonly IKeyboardEventNotifier _keyboardEventNotifier;

        private void Awake()
        {
            if (buttonLabel != null)
                _keyboardEventNotifier.CaseChanged += KeyboardEventNotifier_CaseChanged;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            if (buttonLabel != null)
                _keyboardEventNotifier.CaseChanged -= KeyboardEventNotifier_CaseChanged;
        }

        private void KeyboardEventNotifier_CaseChanged(bool isUpperCase)
        {
            Func<char, char> caseChangeHandler = isUpperCase ? char.ToUpper : char.ToLower;
            SetSymbol(caseChangeHandler(symbol));
        }

        /// <summary>
        /// Установить символ для данной кнопки.
        /// </summary>
        public void SetSymbol(char symbol)
        {
            this.symbol = symbol;
            if (buttonLabel != null)
                buttonLabel.text = symbol.ToString();
        }

        protected override void OnClick()
        {
            _keyboardController.WriteSymbol(symbol);
        }
    }
}

