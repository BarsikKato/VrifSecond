using UnityEngine;

namespace Core.Keyboard.Models
{
    /// <summary>
    /// Раскладка клавиатуры. Представляет из себя именованный набор клавиш с символами.
    /// </summary>
    [CreateAssetMenu(fileName = "KeyboardLayout", menuName = "Keyboard/KeyboardLayout")]
    public sealed class KeyboardLayout : ScriptableObject
    {
        [SerializeField] private string layoutName;
        [SerializeField] private KeySet keySet;

        /// <summary>
        /// Краткое название раскладки.
        /// </summary>
        public string LayoutName => layoutName;

        /// <summary>
        /// Набор символов данной раскладки.
        /// </summary>
        public KeySet KeySet => keySet;
    }
}