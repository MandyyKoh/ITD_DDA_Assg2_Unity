using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject partPrefab,parentObject;


    [SerializeField]
    [Range(1, 1000)]
    int wireLength = 1;

    [SerializeField]
    float partDistance = 0.21f;

    [SerializeField]
    bool reset, spawn, snapFirst, snapLast;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reset) 
        {
            foreach(GameObject temp in GameObject.FindGameObjectsWithTag("Wire")) 
            {
                Destroy(temp);
            }
        }
        if (spawn) 
        {
            Spawn();
            spawn = false;
        }
    }


    public void Spawn()
    {
        int count = (int)(wireLength / partDistance);

        for(int x = 0; x < count; x++) 
        {
            GameObject temp;

            //Spawn Part
            temp = Instantiate(partPrefab, new Vector3(transform.position.x, transform.position.y + partDistance * (x + 1), transform.position.z), Quaternion.identity, parentObject.transform);
            temp.transform.eulerAngles = new Vector3(180, 0, 0);
            temp.name = parentObject.transform.childCount.ToString();
            if (x == 0) 
            {
                //If spawning the first part, destory joint
                Destroy(temp.GetComponent<CharacterJoint>());
                if (snapFirst) 
                {
                    temp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                }
            }

            else 
            {
                //Connects current spawned part to previous spawned part
                temp.GetComponent<CharacterJoint>().connectedBody = parentObject.transform.Find((parentObject.transform.childCount - 1).ToString()).GetComponent<Rigidbody>();
            }
        }

        if (snapLast) 
        {
            parentObject.transform.Find(parentObject.transform.childCount.ToString()).GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
