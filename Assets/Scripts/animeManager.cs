using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class animeManager : MonoBehaviour
{

    public GameObject player;
    public Animator enemyAnimator;
    // Start is called before the first frame update
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination =player.transform.position;
        if ( GetComponent<NavMeshAgent>().velocity.magnitude >1)
        {
            enemyAnimator.SetBool("isRunning",true);
        }
        else{
             enemyAnimator.SetBool("isRunning",false);
        }
        
    }
}
