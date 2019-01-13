using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueOption
{
    public string OptionText;
    public CustomAction OnSelected;
}

public class ShowBranchingDialogueAction : CustomAction
{
    public string Prompt;
    public List<DialogueOption> Options;

    public override void Initiate()
    {
        
    }
}
