using Core.Keyboard.Abstractions;
using Core.Keyboard.Controllers;
using Core.Keyboard.Providers;
using Core.UI;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Keyboard.Views
{
    /// <summary>
    /// Кнопка смены раскладки.
    /// </summary>
    public sealed class ChangeLayoutButtonView : ButtonView
    {
        [SerializeField] private Text buttonLabel;

        [Inject] private readonly IKeyboardController _keyboardController;

        private IEnumerator<IKeyboardLayout> _layoutsEnumerator;

        protected override void Start()
        {
            base.Start();
            SetNextLayout();
        }

        [Inject]
        private void InjectLayouts(IKeyboardLayoutProvider layoutProvider)
        {
            _layoutsEnumerator = layoutProvider
                .GetKeyboardLayouts()
                .GetEnumerator();
        }

        protected override void OnClick()
        {
            SetNextLayout();
        }

        private void SetNextLayout()
        {
            // Циклично переключает раскладки.
            NextLayout();
            SetCurrentLayout();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void NextLayout()
        {
            if (!_layoutsEnumerator.MoveNext())
            {
                _layoutsEnumerator.Reset();
                _layoutsEnumerator.MoveNext();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetCurrentLayout()
        {
            IKeyboardLayout currentLayout = _layoutsEnumerator.Current;
            _keyboardController.SetKeyboardLayout(currentLayout);
            buttonLabel.text = currentLayout.LayoutName;
        }
    }
}

