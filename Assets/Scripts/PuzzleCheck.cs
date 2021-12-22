using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCheck : MonoBehaviour
{
    private int piecesAttachedCount = 0;
    public void PieceAttached() 
    {
        piecesAttachedCount += 1;
        CheckPiecesAttachedCount();
    }
    
    private void CheckPiecesAttachedCount() 
    {
        if(piecesAttachedCount >= 3) 
        {
            DoorHandle.instance.puzzleSolved = true;
            Stopwatch.instance.StopStopwatch("puzzle");
        }
    }
}
