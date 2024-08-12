using Core.Keyboard.Abstractions;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Core.Keyboard.Views
{
    /// <summary>
    /// �����-������������� ��������� ����������.
    /// </summary>
    public sealed class KeyboardLayoutView : MonoBehaviour
    {
        [SerializeField] private Transform layoutKeysRoot;
        [SerializeField] private SymbolKeyButtonView symbolKeyPrefab;
        [SerializeField] private List<RectTransform> layoutKeysRows;

        [Inject] private readonly IKeyboardEventNotifier _keyboardEventNotifier;
        [Inject] private readonly DiContainer _diContainer;

        // ����� ��� ����, ����� �� ����������
        // ���� ����� ������ ��� ����� ���������
        private readonly List<SymbolKeyButtonView> _layoutKeysPool = new();
        
        private void Awake()
        {
            _keyboardEventNotifier.KeyboardLayoutChanged += KeyboardEventNotifier_KeyboardLayoutChanged;
        }

        private void OnDestroy()
        {
            _keyboardEventNotifier.KeyboardLayoutChanged -= KeyboardEventNotifier_KeyboardLayoutChanged;
        }

        private void KeyboardEventNotifier_KeyboardLayoutChanged(IKeyboardLayout layout)
        {
            ChangeLayoutKeys(layout);
        }

        private void ChangeLayoutKeys(IKeyboardLayout layout)
        {
            IReadOnlyList<IKey> keys = layout.KeySet.Keys;
            // ���� ������ � ������� ��������� ������, ��� � ����������,
            // �� ��������� �� � ����.
            if (_layoutKeysPool.Count < keys.Count)
            {
                AddItemsToPool(keys.Count - _layoutKeysPool.Count);
            }

            // ������ ��������� ���� ������ � ��������� ������������ ��������.
            IEnumerator<int> rowLengthsEnumerator = layout.RowLengths.GetEnumerator();
            int currentRow = 0;
            int currentRowFreeSpace = GetCurrentRowLength(rowLengthsEnumerator);
            for (int i = 0; i < _layoutKeysPool.Count; i++)
            {
                SymbolKeyButtonView view = _layoutKeysPool[i];
                view.transform.SetParent(null);
                if (i >= keys.Count)
                {
                    view.gameObject.SetActive(false);
                    continue;
                }

                if (currentRowFreeSpace == 0)
                {
                    currentRow++;
                    currentRowFreeSpace = GetCurrentRowLength(rowLengthsEnumerator);
                }

                SetKey(view, layoutKeysRows[currentRow], keys[i].Symbol);
                currentRowFreeSpace--;
            }

            RebuildLayouts();
        }

        private void AddItemsToPool(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var symbolKeyView = _diContainer
                    .InstantiatePrefabForComponent<SymbolKeyButtonView>(symbolKeyPrefab);

                _layoutKeysPool.Add(symbolKeyView);
            }
        }

        private int GetCurrentRowLength(IEnumerator<int> rowLengthsEnumerator)
        {
            MoveRowLengthsEnumerator(rowLengthsEnumerator);
            return rowLengthsEnumerator.Current;
        }

        private void MoveRowLengthsEnumerator(IEnumerator<int> rowLengthsEnumerator)
        {
            if (!rowLengthsEnumerator.MoveNext())
            {
                rowLengthsEnumerator.Reset();
                rowLengthsEnumerator.MoveNext();
            }
        }

        private void SetKey(SymbolKeyButtonView view, RectTransform rowTransform, char symbol)
        {
            view.transform.SetParent(rowTransform, false);
            view.transform.localRotation = Quaternion.identity;
            view.transform.localScale = Vector3.one;

            view.SetSymbol(symbol);
            view.gameObject.SetActive(true);
        }

        private void RebuildLayouts()
        {
            // ���������, ��� ��� �������������� ����������� Layout
            // � Unity �������� ��������������.
            foreach (RectTransform layout in layoutKeysRows)
            {
                LayoutRebuilder.ForceRebuildLayoutImmediate(layout);
            }
        }
    }
}

