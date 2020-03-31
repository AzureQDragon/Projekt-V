using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    Vector2 endPos;

    playerAnimation playerAnimation;
    Rigidbody2D playerRB;

    public float dashTime;
    public float dashDuration;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimation = GetComponent<playerAnimation>();

        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAnimation.movementAnim();

        Vector2 playerVelocity = playerRB.velocity;

        if ((Input.GetAxis("Horizontal")) < 0) { //moving left
            //playerVelocity.x = -1 * 5;
            transform.Translate (Vector2.left * 5 * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") > 0) { //moving right
            //playerVelocity.x = 5;
            transform.Translate(Vector2.right * 5 * Time.deltaTime);
        }
        if ((Input.GetAxis("Vertical")) > 0) { //moving up
            //playerVelocity.y = -1 * 5;
            transform.Translate (Vector2.up * 5 * Time.deltaTime);
        }
        if (Input.GetAxis("Vertical") < 0) { //moving down
            //playerVelocity.y = 5;
            transform.Translate(Vector2.down * 5 * Time.deltaTime);
        }

        if (Input.GetButton("Dash") && Time.time > dashTime)
        {
  	        dashTime = Time.time + dashDuration;

            Vector2 direction = new Vector2(Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f, Camera.main.ScreenToViewportPoint(Input.mousePosition).y - 0.5f);

            direction.Normalize();

            if (direction != Vector2.zero) {
			   transform.position = Vector2.Lerp((Vector2)transform.position, (Vector2)transform.position + direction * 100 , Time.deltaTime);
		    }

        }
    }
}
