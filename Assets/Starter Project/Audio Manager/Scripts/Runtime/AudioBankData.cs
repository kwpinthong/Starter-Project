using System;
using System.Collections.Generic;

namespace StarterProject.AudioManagerLib
{
    [Serializable]
    public struct AudioBankData
    {
        public AudioNodeType Type;
        public List<AudioClipData> AudioClipDatas;
    }
}
