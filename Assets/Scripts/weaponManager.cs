using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponManager : MonoBehaviour
{

     public GameObject playerCam;
     public float range=100f;
     public float damage =25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
           Shoot();
        }
        
    }

    void Shoot()
    {
        RaycastHit hit;

      if (  Physics.Raycast(playerCam.transform.position, transform.forward,out hit,range))
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
