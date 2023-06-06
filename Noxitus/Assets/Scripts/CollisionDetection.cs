using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CollisionDetection : MonoBehaviour
{
   public WeaponController wc;
   //public GameObject HitParticle;

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Enemy") && wc.IsAttacking)
      {
         other.GetComponent<Animator>().SetTrigger("TriggGetHit");
         var position = transform.position;
         var transform1 = other.transform;
         //Instantiate(HitParticle, new Vector3(transform1.position.x,
        //    position.y, position.z), transform1.rotation);
      }
   }
}
