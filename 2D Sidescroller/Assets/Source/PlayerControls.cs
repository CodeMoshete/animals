using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerControls : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public float JumpSpeed = 250f;
    public bool IsTalking = false;

    private Rigidbody2D rigidBody;
    private float testDist;

	// Use this for initialization
	void Start ()
    {
        Service.Ui.Player = this;
        rigidBody = this.GetComponent<Rigidbody2D>();
        CapsuleCollider2D collider = this.GetComponent<CapsuleCollider2D>();
        testDist = (collider.size.y / 2f) * transform.localScale.y + 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsTalking == false)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Vector3 storedPosition = this.transform.position;
                storedPosition.x = storedPosition.x + MoveSpeed;
                this.transform.position = storedPosition;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Vector3 storedPosition = this.transform.position;
                storedPosition.x = storedPosition.x - MoveSpeed;
                this.transform.position = storedPosition;
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                Vector2 jumpForce = new Vector2(0f, JumpSpeed);
                rigidBody.AddForce(jumpForce);
            }
        }
    }

    private bool isGrounded
    {
        get
        {
            if (rigidBody.velocity.y > 0)
            {
                return false;
            }

            RaycastHit2D[] hits = 
                Physics2D.RaycastAll(transform.position, Vector3.down, testDist);

            for (int i = 0, count = hits.Length; i < count; ++i)
            {
                RaycastHit2D hit = hits[i];
                if (!hit.collider.isTrigger && hit.collider.gameObject != gameObject)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
