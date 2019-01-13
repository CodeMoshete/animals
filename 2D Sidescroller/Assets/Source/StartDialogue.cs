using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour {

    public List<string> Dialogues;
    private bool hasTalked;
    private int DialogueIndex = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.gameObject.layer == LayerMask.NameToLayer("Player") && hasTalked == false)
        {
            ShowNextDialogue();
        }
    }

    public void ShowNextDialogue()
    {
        bool isConversationOver = DialogueIndex == Dialogues.Count - 1;
        UIController.Instance.ShowDialogue(Dialogues[DialogueIndex], isConversationOver, this);
        hasTalked = true;
        DialogueIndex = DialogueIndex + 1;
    }
}
