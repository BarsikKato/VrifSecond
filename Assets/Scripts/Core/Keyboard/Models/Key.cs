using Core.Keyboard.Abstractions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.Keyboard.Models
{
    /// <inheritdoc cref="Core.Keyboard.Abstractions.IKey"/>
    [System.Serializable]
    public struct Key : IKey
    {
        [SerializeField] private char symbol;
        [SerializeField] private Key[] subkeys;

        /// <inheritdoc/>
        public char Symbol => symbol;

        /// <inheritdoc/>
        public IReadOnlyCollection<IKey> Subkeys => subkeys.Select(x => x as IKey).ToArray();

        public Key(char symbol) : this(symbol, null) { }

        public Key(char symbol, Key[] subkeys)
        {
            this.symbol = symbol;
            this.subkeys = subkeys ?? new Key[0];
        }
    }
}
