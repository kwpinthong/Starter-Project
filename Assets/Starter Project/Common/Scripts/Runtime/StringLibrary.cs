using System;
using System.Collections.Generic;
using UnityEngine;

namespace StarterProject.CommonLib
{
    [CreateAssetMenu(fileName = "String Library", menuName = "Starter Project/Common/String Library")]
    public class StringLibrary : ScriptableObject
    {
        [Serializable]
        public struct StringEntry
        {
            public string Key;
            [TextArea]
            public string Value;
        }

        public List<StringEntry> Entries;
    }
}
