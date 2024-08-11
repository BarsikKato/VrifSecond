using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Keyboard.Models
{
    /// <summary>
    /// Клавиша с символом на клавиатуре.
    /// </summary>
    [System.Serializable]
    public struct Key
    {
        [SerializeField] private char symbol;
        [SerializeField] private Key[] subkeys;

        /// <summary>
        /// Символ клавиши.
        /// </summary>
        public char Symbol => symbol;

        /// <summary>
        /// Вложенные клавиши.
        /// </summary>
        public IReadOnlyCollection<Key> Subkeys => subkeys;

        public Key(char symbol) : this(symbol, null) { }

        public Key(char symbol, Key[] subkeys)
        {
            this.symbol = symbol;
            this.subkeys = subkeys ?? new Key[0];
        }
    }
}
