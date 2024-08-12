using Core.Keyboard.Abstractions;
using Core.Keyboard.Controllers;
using Core.Keyboard.Models;
using Core.Keyboard.Providers;
using UnityEngine;
using Zenject;

namespace Installers.Keyboard
{
    public sealed class KeyboardInstaller : MonoInstaller
    {
        [SerializeField] private KeyboardLayout[] keyboardLayouts;

        public override void InstallBindings()
        {
            KeyboardLayoutProvider keyboardLayoutProvider = new KeyboardLayoutProvider(keyboardLayouts);
            Container
                .BindInstance<IKeyboardLayoutProvider>(keyboardLayoutProvider)
                .AsTransient();
            
            KeyboardController controller = new KeyboardController();
            Container
                .BindInstance<IKeyboardController>(controller)
                .AsSingle();

            Container
                .BindInstance<IKeyboardEventNotifier>(controller)
                .AsSingle();
        }
    }
}


