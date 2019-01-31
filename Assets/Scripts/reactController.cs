using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reactController : MonoBehaviour {
    public GameObject[] camAndHands;
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
     foreach(GameObject go in camAndHands)
        {
            if (Vector3.Distance(transform.position, go.transform.position) <= 10)
            {
                anim.SetBool("Granny Away", true);
                return;
            }
        }
        anim.SetBool("Granny Away", false);
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 10);
    }*/
}
