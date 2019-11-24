using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	// Needed to use GUI elements.

public class HighScore : MonoBehaviour
{
	public static int		score = 1000;               // making the score static and public allows you to access it from
														// any other script by simply using HighScore.score

	void Awake() {
		// If the PlayerPrefs HighScore already exists, read it.
		if (PlayerPrefs.HasKey("HighScore")) {
			score = PlayerPrefs.GetInt("HighScore");
		}
		// Sets the current score to the HighScore PlayerPref key.
		PlayerPrefs.SetInt("HighScore", score);					// Creates the PlayerPrefs "HighScore" key if the above "if" statement does not fire. 
	}															// If it does, it will rewrite the key with the same value.
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		// Displays the high score in the Text component of the object.
        Text gt = this.GetComponent<Text>();			// Calling ToString() is not needed, as concentation of another data type with a string
		gt.text = "High Score: " + score;				// converts into string implicitly.
		// Update the PlayerPrefs HighScore if needed.
		if (score > PlayerPrefs.GetInt("HighScore")) {
			PlayerPrefs.SetInt("HighScore", score);
		}
    }
}
