using System;
using UnityEngine;
using UnityEngine.UI;

public enum HudState
{
    Idle,
    LinearDialogue,
    BranchDialogue,
    Transition
}

public class UIController : MonoBehaviour
{
    public GameObject DialoguePanel;
    public Text DialogueText;
    public Button DismissButton;
    public PlayerControls Player;

    public GameObject PromptPanel;
    public Text PromptText;

    public HudState CurrentState { get; private set; }

    private bool isConvoOver;
    private Action OnComplete;

    public static UIController Instance { get; private set;
    }
    void Start ()
    {
        DismissButton.onClick.AddListener(HideDialogue);
        Instance = this;
	}
	
	void Update ()
    {
         if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            HideDialogue();
        }
    }

    public void ShowPrompt(string promptContent)
    {
        PromptPanel.SetActive(true);
        PromptText.text = promptContent;
    }

    public void HidePrompt()
    {
        PromptPanel.SetActive(false);
    }

    public void ShowDialogue(string dialogueContent, bool isConversationOver, Action onComplete)
    {
        CurrentState = HudState.LinearDialogue;
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
            Service.Timers.CreateTimer(0f, ResetCurrentState, null);
            Player.IsTalking = false;
            DialoguePanel.SetActive(false);
            isConvoOver = false;

            if (OnComplete != null)
            {
                OnComplete();
            }

            OnComplete = null;
        }
        else if (OnComplete != null)
        {
            OnComplete();
        }
    }

    private void ResetCurrentState(object cookie)
    {
        CurrentState = HudState.Idle;
    }
}
