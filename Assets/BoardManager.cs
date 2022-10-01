using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType
{
    row,
    column,
    single
}



public class BoardManager : MonoBehaviour
{
    public BoardSpace[] boardSpaces;

    public List<GameObject> InterpretInput(BoardSpace b, TargetType t)
    {
        List<GameObject> occupants = new List<GameObject>();
        switch (t)
        {
            case TargetType.row:
                foreach (BoardSpace s in GetSpacesFromTargetType(b, t))
                {
                    Beast beast = s.GetBeastOccupant();
                    if (beast) occupants.Add(beast.gameObject);
                    Minion minion = s.GetMinionOccupant();
                    if (minion) occupants.Add(minion.gameObject);
                }
                break;
            case TargetType.column:
                foreach (BoardSpace s in GetSpacesFromTargetType(b, t))
                {
                    Beast beast = s.GetBeastOccupant();
                    if (beast) occupants.Add(beast.gameObject);
                    Minion minion = s.GetMinionOccupant();
                    if (minion) occupants.Add(minion.gameObject);
                }
                break;
            case TargetType.single:
                occupants.Add(b.gameObject);
                break;
            default:
                break;
        }
        return occupants;
    }

    public void HoverInput(BoardSpace b, TargetType t)
    {
        foreach (BoardSpace s in GetSpacesFromTargetType(b, t))
        {
            s.PlayHoverFX();
        }
    }

    List<BoardSpace> GetSpacesFromTargetType(BoardSpace b, TargetType t)
    {
        List<BoardSpace> spaces = new List<BoardSpace>();
        int index = FindIndex(b);
        switch (t)
        {
            case TargetType.row:
                int row = Mathf.FloorToInt(index / 5f);
                for (int i = 0; i < 5; i++)
                {
                    spaces.Add(boardSpaces[i + (5 * row)]);
                }
                break;
            case TargetType.column:
                int column = index % 5;
                for (int i = 0; i < 5; i++)
                {
                    spaces.Add(boardSpaces[(i * 5) + column]);
                }
                break;
            case TargetType.single:
                spaces.Add(b);
                break;
            default:
                break;
        }
        return spaces;
    }

    int FindIndex(BoardSpace b)
    {
        int whichIndex = -1;
        for (int i = 0; i < boardSpaces.Length; i++)
        {
            if (b == boardSpaces[i])
            {
                whichIndex = i;
            }
        }
        return whichIndex;
    }

    public void ProcessMovement()
    {
        for (int i = boardSpaces.Length - 1; i >= 0; i--)
        {
            Debug.Log(i);
            Beast beast = boardSpaces[i].GetBeastOccupant();
            if (beast)
            {
                Debug.Log(beast.name);
                if (i <= 19)
                {
                    if (!boardSpaces[i + 5].GetBeastOccupant())
                    {
                        boardSpaces[i].ClearBeastOccupant();
                        boardSpaces[i + 5].SetBeastOccupant(beast, true);
                    }

                } else
                {
                    beast.Attack();
                }

            }
        }
    }

}
