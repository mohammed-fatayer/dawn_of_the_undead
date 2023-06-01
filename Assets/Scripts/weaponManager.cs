using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{

     public GameObject playerCam;
     public float range=100f;
     public float damage =25f;
     public float firerare =1f;

     public Animator PlayerAnimator;

     private float readyToFire;
    // Start is called before the first frame update
    void Start()
    { 
      PlayerAnimator.SetInteger("Movement",0);
    }

    // Update is called once per frame
    void Update()
    {       
        if (Time.time >= readyToFire)
        {
           PlayerAnimator.SetInteger("Fire",-1);
           PlayerAnimator.SetInteger("Movement",0);
        }
        if(Input.GetButtonDown("Fire1") && Time.time >= readyToFire)
        { 
           Shoot();
           PlayerAnimator.SetInteger("Fire",2);
            PlayerAnimator.SetInteger("Movement",-1);
        }
        
    }

    void Shoot()
    {  
     
        RaycastHit hit;

      if (  Physics.Raycast(playerCam.transform.position,- transform.forward,out hit,range))
      {
       
             Debug.Log(" hit  ");
        enemyManager enemymanager = hit.transform.GetComponent<enemyManager>();
        if (enemymanager != null)
        {
            Debug.Log("we hit somthing the zombi ");
            enemymanager.Hit(damage);
        }
      }
    }
}