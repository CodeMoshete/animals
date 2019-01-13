using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject DialoguePanel;
    public Text DialogueText;
    public Button DismissButton;
    public PlayerControls Player;

    private bool isConvoOver;
    private StartDialogue otherCharacter;

    // Use this for initialization
    void Start () {
        DismissButton.onClick.AddListener(HideDialogue);
	}
	
	// Update is called once per frame
	void Update ()
    {
         if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            HideDialogue();
        }
    }

    public void ShowDialogue(string dialogueContent, bool isConversationOver, StartDialogue otherPerson)
    {
        DialogueText.text = dialogueContent;
        DialoguePanel.SetActive(true);
        Player.IsTalking = true;
        isConvoOver = isConversationOver;
        otherCharacter = otherPerson;
        DismissButton.gameObject.SetActive(isConversationOver);
    }

    public void HideDialogue()
    {
        if (isConvoOver)
        {
            Player.IsTalking = false;
            DialoguePanel.SetActive(false);
            isConvoOver = false;
            otherCharacter = null;
        }
        else if (otherCharacter != null)
        {
            otherCharacter.ShowNextDialogue();
        }
    }
}
