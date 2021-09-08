using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardSystem;

namespace DialogueSystem
{
    [CreateAssetMenu(menuName = "DialogueSystem/DialogueChunk")]
    public class DialogueChunk : ScriptableObject
    {
        public string chunkName;
        [TextArea]
        public string[] stenences;
        public DialogueChunk[] bifurcationChunk;
    }
}
