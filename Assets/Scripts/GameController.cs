using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //item to be moved
    public GameObject item;

    public GameObject puzzles;
    
    //to store the new postition
    Vector3 newPosition;


    //control to move left
    public void MoveLeft()
    {
        newPosition = item.transform.position;
        newPosition.x -= 0.1f;
        item.transform.position = newPosition;
    }

    //control to move right
    public void MoveRight()
    {
        newPosition = item.transform.position;
        newPosition.x += 0.1f;
        item.transform.position = newPosition;
    }

    //control to move up
    public void MoveUp()
    {
        newPosition = item.transform.position;
        newPosition.y += 0.1f;
        item.transform.position = newPosition;
    }

    //control to move down
    public void MoveDown()
    {
        newPosition = item.transform.position;
        newPosition.y -= 0.1f;
        item.transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "sensor")
        {
            puzzles.SetActive(true);
        }
    }


}
