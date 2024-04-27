using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guriguriComponentHandler : MonoBehaviour
{
    private GuriGuriBoss guriguriBoss;
    // Update is called once per frame
    void Update()
    {
        if (QuestManager.I.currentQuest.QuestID == 1065)
        {
            if (DialogueHandler.I.dialogueIndex == 4)
            {
                if (guriguriBoss == null) { guriguriBoss = gameObject.AddComponent<GuriGuriBoss>(); }
            }
        }
    }
}
