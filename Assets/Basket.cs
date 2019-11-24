using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	// Enables the use of uGUI features

public class Basket : MonoBehaviour
{
	[Header("Set Dynamically")]
	public Text			scoreGT;

    // Start is called before the first frame update
    void Start()
    {
		// Find a reference to the ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");	// Finds the GameObject in the scene named "ScoreCounter" and assigns to scoreGO

		// Get the Text Component of that GameObject
		scoreGT = scoreGO.GetComponent<Text>();					// Grabs the text portion of the scoreGO GameObject, and assigns to public field scoreGT

		// Set the starting number of points to 0
		scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
		// Get the current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;							// Input.mousePosition only grants x and y axis. z is set to zero.
		
		// The Camera's z position sets how far to push the mouse into 3D
		mousePos2D.z = -Camera.main.transform.position.z;                   // ???

		// Convert the point from 2D screen space into 3D game world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);	// Deadass conversion. This game is running on a 3d engine.

		// Move the x position of this Basket to the x position of the Mouse
		Vector3 pos = this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;

    }

	void OnCollisionEnter(Collision collision) {
		// Find out what hits this basket					// OnCollisionEnter() is a method called whenever another GameObject collides with this basket.
		GameObject collidedWith = collision.gameObject;		// Assigns the colliding object to collidedWith.
		if (collidedWith.tag == "Apple") {					// Checks if the object contains the tag "Apple". Destroys it if it does.
			Destroy(collidedWith);

			// Parse the text portion of the ScoreGT GameObject into an int
			int score = int.Parse(scoreGT.text);					// Parse converts string scoreGT.text to int
			// Add points for catching an apple
			score += 100;
			// Convert the score back into a string and display it
			scoreGT.text = score.ToString();

			// Sets High Score
			if (score > HighScore.score) {
				HighScore.score = score;
			}
		}
	}
}
