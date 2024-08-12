using System.Collections.Generic;

namespace Core.Keyboard.Abstractions
{
    /// <summary>
    /// Раскладка клавиатуры. Представляет из себя именованный набор клавиш с символами.
    /// </summary>
    public interface IKeyboardLayout
    {
        /// <summary>
        /// Краткое название раскладки.
        /// </summary>
        public string LayoutName { get; }

        /// <summary>
        /// Набор символов данной раскладки.
        /// </summary>
        public IKeySet KeySet { get; }

        /// <summary>
        /// Длины рядов символов.
        /// </summary>
        public IEnumerable<int> RowLengths { get; }
    }
}