using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrimaryWepData {

    public class PrimWepAttack {

        public int damage;
        public float knockback;
        public GameObject player;

        public PrimWepAttack(int d, float kb, GameObject pc) {
            damage = d;
            knockback = kb;
            player = pc;
        }

    }
    public static class Iron
    {
        public static int damage = 35;
        public static int knockback = 2;
    }
}

