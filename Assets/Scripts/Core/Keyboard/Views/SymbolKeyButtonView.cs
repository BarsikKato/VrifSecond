using Core.Keyboard.Controllers;
using Core.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Keyboard.Views
{
    /// <summary>
    /// ������ ����� ������� �� ����������.
    /// </summary>
    public sealed class SymbolKeyButtonView : ButtonView
    {
        [SerializeField] private char symbol;
        [SerializeField] private Text buttonLabel;

        [Inject] private readonly IKeyboardController _keyboardController;

        /// <summary>
        /// ���������� ������ ��� ������ ������.
        /// </summary>
        public void SetSymbol(char symbol)
        {
            this.symbol = symbol;
            buttonLabel.text = symbol.ToString();
        }

        protected override void OnClick()
        {
            _keyboardController.WriteSymbol(symbol);
        }
    }
}

