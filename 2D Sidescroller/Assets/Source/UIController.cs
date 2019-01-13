using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private enum HudState
    {
        Idle,
        LinearDialogue,
        BranchDialogue,
        Transition
    }

    public GameObject DialoguePanel;
    public Text DialogueText;
    public Button DismissButton;
    public PlayerControls Player;

    private bool isConvoOver;
    private Action OnComplete;

    public static UIController Instance { get; private set;
    }
    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
        DismissButton.onClick.AddListener(HideDialogue);
        Instance = this;
	}
	
	// Update is called once per frame
	void Update ()
    {
         if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            HideDialogue();
        }
    }

    public void ShowDialogue(string dialogueContent, bool isConversationOver, Action onComplete)
    {
        DialogueText.text = dialogueContent;
        DialoguePanel.SetActive(true);
        Player.IsTalking = true;
        isConvoOver = isConversationOver;
        OnComplete = onComplete;
        DismissButton.gameObject.SetActive(isConversationOver);
    }

    public void HideDialogue()
    {
        if (isConvoOver)
        {
            Player.IsTalking = false;
            DialoguePanel.SetActive(false);
            isConvoOver = false;
            OnComplete = null;
        }
        else if (OnComplete != null)
        {
            OnComplete();
        }
    }
}
