using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGaze : MonoBehaviour
{
    public GameObject selected = null;

    public LayerMask layerMask = 9;

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100.0f, Color.yellow);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100.0f, layerMask))
        {
            if (hit.transform != null)
            {
                var interactable = hit.transform.GetComponent<SimpleInteractable>();
                if (interactable != null)
                {
                    interactable.OnSelectEnter();
                }
                selected = hit.collider.gameObject;
            }
        }
        else 
        {
            if (selected != null)
            {
                var interactable = selected.GetComponent<SimpleInteractable>();
                if(interactable != null)
                {
                    interactable.OnSelectExit();
                }
            }

            selected = null;
        }
    }
}

