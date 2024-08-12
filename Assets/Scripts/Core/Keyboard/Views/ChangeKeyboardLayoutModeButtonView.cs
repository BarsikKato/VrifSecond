using Core.Keyboard.Abstractions;
using Core.Keyboard.Controllers;
using Core.Keyboard.Models;
using Core.UI;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Core.Keyboard.Views
{
    /// <summary>
    ///  нопка смены режима с ввода раскладки на ввод символов.
    /// </summary>
    public sealed class ChangeKeyboardLayoutModeButtonView : ButtonView
    {
        [SerializeField] private UnityEvent ModeEnabled;
        [SerializeField] private UnityEvent ModeDisabled;

        [SerializeField] private KeyboardLayout keyboardLayoutMode;

        [Inject] private readonly IKeyboardController _keyboardController;
        [Inject] private readonly IKeyboardEventNotifier _keyboardEventNotifier;

        private IKeyboardLayout _lastKeyboardLayout;
        private bool isOn = false;

        private void Awake()
        {
            _keyboardEventNotifier.KeyboardLayoutChanged += KeyboardEventNotifier_KeyboardLayoutChanged;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            _keyboardEventNotifier.KeyboardLayoutChanged -= KeyboardEventNotifier_KeyboardLayoutChanged;
        }

        private void KeyboardEventNotifier_KeyboardLayoutChanged(IKeyboardLayout layout)
        {
            if (layout != keyboardLayoutMode)
            {
                _lastKeyboardLayout = layout;
                isOn = false;
                return;
            }

            isOn = true;
        }

        protected override void OnClick()
        {
            UnityEvent eventToInvoke = isOn ? ModeDisabled : ModeEnabled;
            eventToInvoke?.Invoke();

            IKeyboardLayout nextLayout = isOn ? _lastKeyboardLayout : keyboardLayoutMode;
            _keyboardController.SetKeyboardLayout(nextLayout);
        }
    }
}