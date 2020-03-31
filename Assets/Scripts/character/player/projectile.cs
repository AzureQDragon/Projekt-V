﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimaryWepData;

public class projectile : MonoBehaviour
{
    Animator projectileAnim;
	public float speed;
	public Vector2 direction;
	public float maxRange;

    PrimWepAttack weapon;

	// Use this for initialization
	void Start () {
        weapon = new PrimWepAttack(Iron.damage, Iron.knockback, GameObject.FindGameObjectWithTag("Player"));
		projectileAnim = GetComponent<Animator>();
	}

    public void setDirection(Vector2 directionToBeSet) {
        direction = directionToBeSet;
    }

	// Update is called once per frame
	void Update () {
		if (direction != Vector2.zero) {
			transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;
		}
		else {
			Debug.LogError(this.gameObject.name + " lacks a direction!");
			DestroyImmediate(this);
		}
		if (Vector2.Distance(transform.position, GameObject.FindWithTag("Player").transform.position)>maxRange) {
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)	{
		if (!collision.gameObject.CompareTag("Player")&&collision.gameObject.CompareTag("enemy")) {
			if (collision.gameObject.CompareTag("enemy")) {
				collision.gameObject.SendMessage("takeMeleeDamage", weapon, SendMessageOptions.DontRequireReceiver);
			}
            projectileAnim.SetTrigger("collision");
            Destroy(this.gameObject);
		}
	}
}
