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
                
            Container
                .Bind<IKeyboardController>()
                .To<KeyboardController>()
                .AsSingle();
        }
    }
}


