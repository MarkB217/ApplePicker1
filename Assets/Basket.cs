using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // enables use of uGUI features

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounter;

    private void Start()
    {
      //Find a reference to ScoreCounter GameObject
      GameObject scoreGO = GameObject.Find("ScoreCounter");
        // Get the Text Component of that GameObject
        scoreCounter = scoreGO.GetComponent<ScoreCounter>();

    }


    // Update is called once per frame
    void Update()
    {
        // Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        // The Camera’s z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from 2D screen space into 3D game world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);   

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
     }

    private void OnCollisionEnter(Collision collision)
    {                            
        // Find out what hit this basket
    GameObject collidedWith = collision.gameObject;                     
        if (collidedWith.tag == "Apple")
        {                         
            Destroy(collidedWith);

            //Increase the score
            scoreCounter.score += 100;
            HighScore.TRY_SET_HIGH_SCORE(scoreCounter.score);

        }
     }
}