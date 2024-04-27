using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seoriseoriComponetHandler : MonoBehaviour
{
    public SeoriSeoriBoss seoriseoriBoss;
    // Update is called once per frame
    void Update()
    {
        if (QuestManager.I.currentQuest.QuestID == 1053)
        {
            if (DialogueHandler.I.dialogueIndex == 4)
            {
                if (seoriseoriBoss == null) { seoriseoriBoss = gameObject.AddComponent<SeoriSeoriBoss>(); }
            }
        }
    }
}
