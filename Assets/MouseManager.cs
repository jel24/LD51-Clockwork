using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{

    [SerializeField] Camera mainCamera;

    void Update()
    {
        Hover();
    }



    public void MouseClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Card card = CheckForCard();
            Debug.Log(card);
            if (card) card.Play();
        }

    }

    public void Hover()
    {
        Card card = CheckForCard();
        if (card) card.Hover();
    }

    Card CheckForCard()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray: ray, hitInfo: out RaycastHit hit) && hit.collider)
        {
            if (hit.collider.gameObject.tag == "Card")
            {
                return hit.collider.gameObject.GetComponent<Card>();
            } else {
                return null;
            }
        } else
        {
            return null;
        }
    }
}
