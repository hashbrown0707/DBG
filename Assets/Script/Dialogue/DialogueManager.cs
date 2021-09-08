using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardSystem;
using Utility;

namespace DialogueSystem
{
    public class DialogueManager : Singleton<DialogueManager>
    {
        [Tooltip("整個對話顯示的母物件")]
        public GameObject dialogueDisplay;

        [Tooltip("顯示對話的Text")]
        public Text dialogueDisplayContent;

        public Hand hand;

        private Queue<string> textQueue = new Queue<string>();
        private DialogueChunk currentChunk;

        //do a c# action on StartDialogue

        public void StartDialogue(DialogueChunk dialogueChunk)
        {
            if (textQueue == null)
                return;

            dialogueDisplay.gameObject.SetActive(true);
            currentChunk = dialogueChunk;
            textQueue.Clear();

            foreach (string sentence in dialogueChunk.stenences)
                textQueue.Enqueue(sentence);

            ShowNextDialogueText();
        }


        public void ShowNextDialogueText(Action action = null)
        {
            if (currentChunk.bifurcationChunk.Length > 0 && textQueue.Count == 0)
            {
                //DisplayChooseCard(currentChunk.bifurcationChunk, action);
                return;
            }
            else if (currentChunk.bifurcationChunk.Length == 0 && textQueue.Count == 0)
            {
                EndDialogue();
                return;
            }

            //todo: change dequeue dialogue to coroutine
            string sentence = textQueue.Dequeue();
            dialogueDisplayContent.text = sentence;
        }

        private void EndDialogue()
        {
            currentChunk = null;
            dialogueDisplay.gameObject.SetActive(false);
            hand.RemoveAllCard();
        }
        
        //private void DisplayChooseCard(DialogueChunk[] bifurcationChunk, Action action)
        //{
        //    if (bifurcationChunk.Length <= 0)
        //        return;

        //    hand.RemoveAllCard();

        //    //spawn choose cards to hand panel && give all choose cards for the specific bifurcation dialogue chunk
        //    //then the chosen choose card will call ICard.OnUse()
        //    foreach (var chunk in bifurcationChunk)
        //    {
        //        ChooseCard card = CardSpawner.Instance.SpawnChooseCard(chunk, action);
        //        hand.AddCard(card);
        //    }
        //}

    }
}
