using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold_and_TakeObject : MonoBehaviour
{
    public float maxDistance = 2.0f;
    public LayerMask layer;
    public List<string> tagsHoldableObjects;
    public List<string> tagsTakeableObjects;
    public List<Transform> positionsInHand;
    private bool holding = false;
    private Transform objects;

    void Update()
    {
        HoldAndTakeObjects();
    
    }

    void HoldAndTakeObjects()
    {
        if (Input.GetMouseButtonUp(0))
        {
            holding = false;
        }
        if (holding)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                holding = false;
            }
            int index = 0;
            objects.position = positionsInHand[index].position;
            objects.rotation = positionsInHand[index].rotation;
        }
        else
        {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance, layer, QueryTriggerInteraction.Ignore))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    string tagObject = tagsTakeableObjects.Find((tag) =>
                    {
                        if (hit.transform.gameObject.tag == tag)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    });

                    if (tagObject != null)
                    {
                        holding = true;
                        objects = hit.transform;
                    }


                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    string tagObject = tagsHoldableObjects.Find((tag) =>
                    {
                        if (hit.transform.gameObject.tag == tag)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    });

                    if (tagObject != null)
                    {
                        holding = true;
                        objects = hit.transform;
                    }
                }


            }



        }
    }

    
}
