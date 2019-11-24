using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
	public static float		bottomY = -23f;				// Static classes apply to every instance of an object, but does not appear in the inspector, as it is not changeable.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY) {
			Destroy(this.gameObject);			// this refers to the script itself. this.gameObject refers to the object it is attached to.
												// Therefore, we need to specify this.gameObject or the script will remove itself, while the sphere remains.

			// Get a reference to the ApplePicker component of Main Camera
			ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();			// Camera.main is a built-in static variable referring to the main camera.
																					// Gets the component "ApplePicker" and assigns to to apScript
			// Call the public AppleDestroyed() method of apScript
			apScript.AppleDestroyed();												// Now that the "ApplePicker" script is assigned, we can now call AppleDestroyed() found in
																					// the "ApplePicker" script component of the Main Camera.

		}
    }
}
