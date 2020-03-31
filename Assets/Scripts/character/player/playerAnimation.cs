using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwordData;

public class playerAnimation : MonoBehaviour
{
    public Animator playerAnim;
    public float attackMeleeTime;
    public float attackPrimTime;
    public float attackPrimDuration;
    public float attackDuration;
    Shoot Shoot;
    slash slash;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        slash = GameObject.FindGameObjectWithTag("playerMelee").GetComponent<slash>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2")&&Time.time > attackMeleeTime)
        {
  	        attackMeleeTime = Time.time + attackDuration;
            playerAnim.Play("attack");

            slash.dealDamage(slash.target);
        }

        if (Input.GetButton("Fire1")&&Time.time > attackPrimTime)
        {
  	        attackPrimTime = Time.time + attackPrimDuration;
            playerAnim.Play("attack");

            GetComponent<Shoot>().rangeAttack();
        }
        
    }

    public void movementAnim()
    {    
        Vector3 endPos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        playerAnim.SetFloat("y", (endPos.y - 0.5f) * 2);
        playerAnim.SetFloat("x", (endPos.x - 0.5f) * 2);


        Vector3 diff = new Vector3(endPos.x - 0.5f, endPos.y - 0.5f);

        diff.Normalize();

        float rot_z = (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg) + 79f; //<--- umm the (+79f) if because of it being wierd
        //TODO: umm fixt the animation thing, there is a wierd thing where the slash will not follow the cursor exactly and
        //will always be a bit off
        
        GameObject.FindGameObjectWithTag("playerAttackPivot").transform.rotation = Quaternion.Euler(0, 0, rot_z);
    }
}
