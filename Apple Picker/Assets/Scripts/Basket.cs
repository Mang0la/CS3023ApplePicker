/***
 * Created by: Thomas Nguyen
 * Date Created: 2/5/2022
 * 
 * Last Edited: 2/7/2022
 * Last Edited by: Thomas Nguyen
 * 
 * Description: Basket moving apple collision logic
***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //using UI library

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //get the current position of the mouse on the screen using input
        Vector3 mousePos2D = Input.mousePosition;

        //the camera's z position sets how far to push the mouse into 3D
        mousePos2D.z = Camera.main.transform.position.z;

        //convert the point from 2D screen into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //move the x position of the basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision coll)
    {
        // Find out what hit this basket
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();

            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
