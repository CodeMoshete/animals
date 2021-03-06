﻿using System;
using System.Collections.Generic;
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

    public List<Button> OptionButtons;
    public List<Text> OptionButtonTexts;
    private List<DialogueOption> currentOptions;

    public GameObject PromptPanel;
    public Text PromptText;

    public HudState CurrentState { get; private set; }

    private bool isConvoOver;
    private Action OnComplete;

    public static UIController Instance { get; private set;
    }
    void Start ()
    {
        for (int i = 0, count = OptionButtons.Count; i < count; ++i)
        {
            int curr = i;
            OptionButtons[i].onClick.AddListener(delegate() { DialogueBranchSelected(curr); });
        }

        DismissButton.onClick.AddListener(HideDialogue);
        Instance = this;
	}
	


	void Update ()
    {
         if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)) && 
            CurrentState == HudState.LinearDialogue)
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
        DismissButton.gameObject.SetActive(false);
        PromptPanel.SetActive(false);
    }

    public void ShowBranchingDialogue(string prompt, List<DialogueOption> options)
    {
        CurrentState = HudState.BranchDialogue;
        DialoguePanel.SetActive(true);
        DismissButton.gameObject.SetActive(false);
        DialogueText.text = prompt;
        currentOptions = options;
        int numOptsButtons = OptionButtons.Count;
        int numOptions = Math.Min(options.Count, numOptsButtons);
        for (int i = 0; i < numOptions; ++i)
        {
            OptionButtons[i].gameObject.SetActive(true);
            OptionButtonTexts[i].text = options[i].OptionText;
        }
    }

    private void DialogueBranchSelected(int index)
    {
        for (int i = 0, count = OptionButtons.Count; i < count; ++i)
        {
            OptionButtons[i].gameObject.SetActive(false);
        }
        DialoguePanel.SetActive(false);
        if (currentOptions[index].OnSelected != null)
        {
            currentOptions[index].OnSelected.Initiate();
        }
        currentOptions = null;
    }

    public void ShowLinearDialogue(string dialogueContent, bool isConversationOver, bool showDismiss, Action onComplete)
    {
        CurrentState = HudState.LinearDialogue;
        DialogueText.text = dialogueContent;
        DialoguePanel.SetActive(true);
        Player.IsTalking = true;
        isConvoOver = isConversationOver;
        OnComplete = onComplete;
        DismissButton.gameObject.SetActive(isConversationOver && showDismiss);
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
