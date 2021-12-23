using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck : MonoBehaviour
{
    private int piecesAttachedCount = 0;

    public GameObject doorHandle;
    public void PieceAttached() 
    {
        piecesAttachedCount += 1;
        CheckPiecesAttachedCount();
    }
    
    private void CheckPiecesAttachedCount() 
    {
        if(piecesAttachedCount >= 3) 
        {
            doorHandle.GetComponent<DoorHandle>().puzzleSolved = true;
            Stopwatch.instance.StopStopwatch("puzzle");
        }
    }
}
