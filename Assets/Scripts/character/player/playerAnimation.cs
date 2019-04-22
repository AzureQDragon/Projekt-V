﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using swordData;

public class playerAnimation : MonoBehaviour
{
    public Animator playerAnim;
    public float attackTime;
    public float attackDuration;
    slash slash;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        slash = GameObject.FindGameObjectWithTag("playerAttack").GetComponent<slash>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2")&&Time.time > attackTime)
        {
  	        attackTime = Time.time + attackDuration;
            playerAnim.Play("attack");
            
            slash.dealDamage(slash.target);
        }
        
    }

    public void movementAnim()
    {    
        Vector2 endPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float yResult = float.Parse(((endPos.y - 0.5)*2).ToString("0.0000"));
        float xResult = float.Parse(((endPos.x - 0.5)*2).ToString("0.0000"));

        playerAnim.SetFloat("y", -yResult);
        playerAnim.SetFloat("x", xResult);

        float direction = 0;

        if (!(endPos.y >= 0.5625*endPos.x + 0.5) && (endPos.y <= -0.5625*endPos.x + 0.5))
        {   //moving up
            //insert joke about moving up in the world here
            direction = 0f;
        }

        else if ((endPos.y >= 0.5625*endPos.x + 0.5) && !(endPos.y <= -0.5625*endPos.x + 0.5))
        {   //moving down
            direction = 180f;
        }

        if ((endPos.y >= 0.5625*endPos.x + 0.5) && (endPos.y <= -0.5625*endPos.x + 0.5))
        {   //moving left
            direction = -90f;
        }

        else if (!(endPos.y >= 0.5625*endPos.x + 0.5) && !(endPos.y <= -0.5625*endPos.x + 0.5))
        {   //moving right
            direction = 90f;
        }

        GameObject.FindGameObjectWithTag("playerAttack").transform.rotation = Quaternion.Euler(0, 0, direction);
    }
}
