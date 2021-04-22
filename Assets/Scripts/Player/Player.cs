using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] GameManager manager;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit,Mathf.Infinity) && hit.collider.CompareTag("CanPlace"))
            {
                if(manager.current)
                {
                    if ((manager.gold - manager.current.GetComponent<Monkey>().cost)>= 0)
                    {
                        manager.gold -= manager.current.GetComponent<Monkey>().cost;
                        manager.SetGoldOnScreen();
                        GameObject @object = Instantiate(manager.current);
                        @object.transform.position = hit.point + Vector3.up;
                    }
                    else
                    {
                        manager.MessageERROR();
                    }
                }
            }
        }
    }
}
