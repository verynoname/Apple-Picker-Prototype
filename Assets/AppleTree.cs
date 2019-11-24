using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector you darn nitwit")]

    public GameObject   applePrefab;						// Prefab for instantiating apples

    public float        speed = 1f;							// Speed at which AppleTree moves

	public float		leftAndRightEdge = 10f;				// Distance where AppleTree turns around

	public float		chanceToChangeDirections = 0.1f;	// Chance that the AppleTree will change directions

	public float		secondsBetweenAppleDrops = 1f;		// Rate at which Apples will be instantiated.

    // Start is called before the first frame update
    void Start()
    {
        // Dropping apples every second
		Invoke ("DropApple", 2f);									// Invoke() invokes a named function after 2.0 seconds
    }

	void DropApple() {												// Creating a custom function DropApple(). is Invoked as Invoke("DropApple", seconds)
		GameObject apple = Instantiate<GameObject>(applePrefab);	// Creates an instance of applePrefab and assigns it to GameObject variable apple
		apple.transform.position = transform.position;				// The position of this apple object is set to the object of the attached object (AppleTree)
		Invoke( "DropApple", secondsBetweenAppleDrops );			// Reinvokes DropApple() with the interval set with secondsBetweenAppleDrops
	}

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
		Vector3 pos = transform.position;		// Reads the applied object (AppleTree)'s position, and stores it into pos
		pos.x += speed * Time.deltaTime;		// Adds the speed value * Time.deltaTime to the x coord of the pos value
		transform.position = pos;				// Applies the adjusted pos value to the AppleTree's position.

		// Changing Direction
		if (pos.x < -leftAndRightEdge) {
			speed = Mathf.Abs(speed);			// If the x value is below the negative of leftAndRightEdge, flip the speed value. Causes the tree to move right.
		} else if (pos.x > leftAndRightEdge) {
			speed = -Mathf.Abs(speed);			// Causes the tree to move left.
		} else if (Random.value < chanceToChangeDirections) {		
			speed *= -1;											
		}
    }
	void FixedUpdate() {		// Randomly changing directions is under FixedUpdate, which always updates 50 times per second. regular Update() is called each frame possible.
		if (Random.value < chanceToChangeDirections) {              // Random.value returns a random float between 0.0 and 1.0
			speed *= -1;                                            // which flips the speed if it is below chanceToChangeDirections
		}
	}
}
