using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTouch : MonoBehaviour
{
    public GameObject player;
    // public float movementRangeMax;
    // public float movementRangeMin;
    // public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //movement(movementRangeMin, movementRangeMax);
        
    }

    public void movement(float movementRangeMin, float movementRangeMax, float speed) {
        Vector2 originalEnemyPosition = transform.position;
		
        if (((Vector2.Distance(transform.position, player.transform.position) < movementRangeMax) &&
            (Vector2.Distance(transform.position, player.transform.position) > movementRangeMin)) &&
            !GameObject.Find("UI").GetComponent<PauseStuff>().paused) {

			transform.position = Vector2.MoveTowards(transform.position,player.transform.position, speed*Time.deltaTime);
			
            

            gameObject.SendMessage("updateMovementAnim", originalEnemyPosition, SendMessageOptions.DontRequireReceiver);
		}
		//testEnemyMageAnim.SetInteger("testEnemyMageFacing", testEnemyMageDirection);
	}


    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            gameObject.SendMessage("dealMeleeDamage", collider.gameObject, SendMessageOptions.DontRequireReceiver);

        }
    }

    void death(int health) {
        if (health <= 0) {
            this.SendMessage("die", SendMessageOptions.DontRequireReceiver);
            this.enabled = false;
        }
    }
}
