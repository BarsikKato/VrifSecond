using ModestTree;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Utilities;

namespace Core.Keyboard.Models
{
    [CustomEditor(typeof(KeySet))]
    public sealed class KeySetEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Загрузить данные из файла"))
            {
                Key[] keys = ReadData();

                if (keys.Length > 0)
                {
                    IDataLoader<Key[]> keySetDataLoader = target as IDataLoader<Key[]>;
                    keySetDataLoader.LoadData(keys);
                }
            }

            if (GUI.changed)
            {
                EditorUtility.SetDirty(target);
            }
        }

        private Key[] ReadData()
        {
            string selectedFile = EditorUtility.OpenFilePanel("Файл с данными набора", string.Empty, "txt, csv");
            if (selectedFile == string.Empty)
            {
                return new Key[0];
            }

            // Предполагаемый формат одной строки: key,subkey,subkey...
            string[] fileLines = File.ReadAllLines(selectedFile);
            Key[] keys = new Key[fileLines.Length];
            for (int i = 0; i < fileLines.Length; i++)
            {
                keys[i] = ParseKey(fileLines[i]);
            }

            return keys;
        }

        private Key ParseKey(string line)
        {
            string[] symbols = line.Split(',');
            Key[] subkeys = null;
            if (symbols.Length > 1)
            {
                subkeys = symbols
                    .Where(x => symbols.IndexOf(x) > 0)
                    .Select(x => new Key(x[0]))
                    .ToArray();
            }

            return new Key(symbols[0][0], subkeys);
        }
    }
}

