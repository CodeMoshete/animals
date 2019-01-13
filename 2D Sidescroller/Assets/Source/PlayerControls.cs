using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    public float MoveSpeed = 1f;
    public float JumpSpeed = 250f;
    public bool IsTalking = false;

	// Use this for initialization
	void Start ()
    {
        Service.Ui.Player = this;
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

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector2 jumpForce = new Vector2(0f, JumpSpeed);
                this.GetComponent<Rigidbody2D>().AddForce(jumpForce);
            }
        }
    }
}
