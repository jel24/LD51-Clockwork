using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MouseManager : MonoBehaviour
{

    [SerializeField] Camera mainCamera;
    [SerializeField] BoardManager boardManager;
    [SerializeField] GameObject boardTargetUI;

    bool boardTarget = false;
    TargetType activeTargetType;
    Card activeCard;

    void Update()
    {
        Hover();
    }



    public void MouseClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (boardTarget)
            {
                BoardSpace space = CheckForSpace();
                Debug.Log(space);

                if (space)
                {
                    activeCard.TargetsFound(boardManager.InterpretInput(space, activeTargetType));
                    activeCard.PlayFX(space);
                    boardTarget = false;
                    boardTargetUI.SetActive(false);
                    activeCard = null;
                }
            } else
            {
                Card card = CheckForCard();
                Debug.Log(card);
                if (card) card.Play();
            }

        }

    }

    public void Hover()
    {
        if (boardTarget)
        {
            BoardSpace space = CheckForSpace();
            if (space)
            {
                boardManager.HoverInput(space, activeTargetType);
            }
        }
        else
        {
            Card card = CheckForCard();
            if (card) card.Hover();
        }
        
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

    BoardSpace CheckForSpace()
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray: ray, hitInfo: out RaycastHit hit) && hit.collider)
        {
            if (hit.collider.gameObject.tag == "Space")
            {
                return hit.collider.gameObject.GetComponent<BoardSpace>();
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
    }

    public void ToggleBoardTarget(TargetType t, Card originator)
    {
        boardTarget = true;
        activeTargetType = t;
        boardTargetUI.SetActive(true);
        activeCard = originator;
    }
}
