using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider2D))]
public class AreaTrigger : MonoBehaviour
{
    public bool DisableEnterActionsOnUse;
    public List<CustomAction> EnterActions;

    public bool DisableExitActionsOnUse;
    public List<CustomAction> ExitActions;

    private bool isEnterUsed;
    private bool isExitUsed;

    public void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (DisableEnterActionsOnUse && isEnterUsed)
            return;

		if(collisionObject.gameObject.layer == LayerMask.NameToLayer("Player"))
		{
			for(int i = 0, count = EnterActions.Count; i < count; i++)
			{
                isEnterUsed = true;
				EnterActions[i].Initiate();
			}
		}
	}

    public void OnTriggerExit2D(Collider2D other)
    {
        if (DisableExitActionsOnUse && isExitUsed)
            return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            for (int i = 0, count = ExitActions.Count; i < count; i++)
            {
                isExitUsed = true;
                ExitActions[i].Initiate();
            }
        }
    }
}
