using System.Collections.Generic;
using UnityEngine;

public class InteractTrigger : MonoBehaviour
{
    public string PromptText;

    public bool DisableInteractActionsOnUse;
    public List<CustomAction> InteractActions;

    private bool isInteractUsed;
    private bool isInsideArea;

    public void Update()
    {
        if (!isInteractUsed && isInsideArea && Input.GetKeyDown(KeyCode.Return) && Service.Ui.CurrentState == HudState.Idle)
        {
            isInteractUsed = DisableInteractActionsOnUse;
            for (int i = 0, count = InteractActions.Count; i < count; i++)
            {
                if (!string.IsNullOrEmpty(PromptText))
                {
                    Service.Ui.HidePrompt();
                }
                InteractActions[i].Initiate();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (DisableInteractActionsOnUse && isInteractUsed)
            return;

        if (collisionObject.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!string.IsNullOrEmpty(PromptText))
            {
                Service.Ui.ShowPrompt(PromptText);
            }
            isInsideArea = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (DisableInteractActionsOnUse && isInteractUsed)
            return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (!string.IsNullOrEmpty(PromptText))
            {
                Service.Ui.HidePrompt();
            }
            isInsideArea = false;
        }
    }
}
