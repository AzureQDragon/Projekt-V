using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimaryWepData;

public class Shoot : MonoBehaviour
{
    public bool canHit = false;
    public GameObject projectilePrefab;

    PrimWepAttack weapon;
    // Start is called before the first frame update
    void Start()
    {
        weapon = new PrimWepAttack(Iron.damage, Iron.knockback, GameObject.FindGameObjectWithTag("Player"));
        canHit = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rangeAttack() {

        Vector3 diff = new Vector3(Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f, Camera.main.ScreenToViewportPoint(Input.mousePosition).y - 0.5f);

        diff.Normalize();

        float rot_z = (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg);

        Vector2 direction = new Vector2(Camera.main.ScreenToViewportPoint(Input.mousePosition).x - 0.5f, Camera.main.ScreenToViewportPoint(Input.mousePosition).y - 0.5f);

        direction.Normalize();


        GameObject firedProjectile = Instantiate(projectilePrefab, (Vector2)transform.position, Quaternion.Euler(0f, 0f, 180 + rot_z));
        
        firedProjectile.SendMessage("setDirection", direction, SendMessageOptions.DontRequireReceiver);
    }

    // void OnTriggerStay2D(Collider2D collider)
    // {
    //     if (collider.gameObject.tag == "enemy")
    //     {
    //         target = collider.gameObject;
    //         canHit = true;
    //     }
    // }

    /* void OnTriggerExit2D(Collider2D collider)
    {
        canHit = false;
    } */

    // public void dealDamage(GameObject target)
    // {
    //     if (canHit)
    //     {
    //         target.SendMessage("takeMeleeDamage", PrimWepAttack, SendMessageOptions.DontRequireReceiver);
    //     }
    // }
}
