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
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            if (hit.collider && hit.collider.CompareTag("CanPlace") && manager.current)
            {
                manager.gold -= manager.current.GetComponent<Monkey>().cost;
                manager.current.GetComponent<Monkey>().dontAttack = false;
                manager.current.layer = 0;
                manager.SetGoldOnScreen();
                manager.current.transform.position = hit.point + Vector3.up;
                manager.current = null;
            }
        }
        else
        {
            if(manager.current)
            {
                manager.current.transform.position = hit.point + Vector3.up;
            }
        }
    }
}
