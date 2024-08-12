using Core.Keyboard.Abstractions;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Keyboard.Models
{
    /// <inheritdoc cref="Core.Keyboard.Abstractions.IKeyboardLayout"/>
    [CreateAssetMenu(fileName = "KeyboardLayout", menuName = "Keyboard/KeyboardLayout")]
    public sealed class KeyboardLayout : ScriptableObject, IKeyboardLayout
    {
        [SerializeField] private string layoutName;
        [SerializeField] private KeySet keySet;
        [SerializeField] private int[] rowLengths;

        /// <inheritdoc/>
        public string LayoutName => layoutName;

        /// <inheritdoc/>
        public IKeySet KeySet => keySet;

        /// <inheritdoc/>
        public IEnumerable<int> RowLengths => rowLengths;
    }
}