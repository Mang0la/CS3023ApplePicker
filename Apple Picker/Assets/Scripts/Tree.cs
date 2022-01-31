/***
 * Created by: Thomas Nguyen
 * Date Created: 1/31/2022
 * 
 * Last Edited: 1/31/2022
 * Last Edited by: Thomas Nguyen
 * 
 * Description: Controls tree movement and apples spawning
***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{

    public GameObject applePrefab;

    public float speed = 50f;

    public float leftAndRightEdge = 25f;

    public float chanceToChangeDirections = 0.1f;

    public float secondsBetweenAppleDrops = 1f;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position; //moves apple to tree position
        Invoke("DropApple", secondsBetweenAppleDrops); //calls the same function to repeatedly drop apples
    }

    // Update is called once per frame
    void Update()
    {
        //Move every frame
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); //move right
        }//end if (pos.x < -leftAndRightEdge)
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); //move left
        }//end else if (pos.x > leftAndRightEdge)
 


    }

    private void FixedUpdate()
    {
       if (Random.value < chanceToChangeDirections)
        {
            speed *= -1; //randomly change direction
        }
    }
}
