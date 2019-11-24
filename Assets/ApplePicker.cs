using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;	// Required to work with scenes.

public class ApplePicker : MonoBehaviour
{
	[Header("Set in Inspector")]
	public GameObject		basketPrefab;
	public int				numBaskets = 3;
	public float			basketBottomY = -14f;
	public float			basketSpacingY = 2f;
	public List<GameObject>	basketList;

    // Start is called before the first frame update
    void Start()
    {
		basketList = new List<GameObject>();
        for (int i = 0; i<numBaskets; i++) {
			GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
			Vector3 pos = Vector3.zero;
			pos.y = basketBottomY + (basketSpacingY * i);					//pos.y is applied to the bottom basket, which is -14f + 0, then the second is -14f + 2 and so on.
			tBasketGO.transform.position = pos;
			basketList.Add(tBasketGO);						// Adds the freshly instantiated baskets to a list. The first is the bottom one, the last is the top one.
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void AppleDestroyed() {														// AppleDestroyed() must be declared public to be called by other classes. Methods/Functions
																						// are private by default and cannot be seen or used by other classes.
		// Destroy all of the falling apples.
		GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");			// GameObject.FindGameObjectsWithTag("Apple") returns an array of all existing GameObjects with the "Apple" tag.
		foreach (GameObject tGO in tAppleArray) {										// The foreach loop then uses Destroy() on each object on the array.
			Destroy(tGO);
		}

		// Destroy one of the Baskets
		// Get the index of the last Basket in basketlist (which is the topmost basket in this case)
		int basketIndex = basketList.Count - 1;	
		// Get a reference to that Basket GameObject
		GameObject tBasketGO = basketList[basketIndex];	
		// Remove the topmost/last basket in the list, then destroy it.
		basketList.RemoveAt(basketIndex);
		Destroy(tBasketGO);

		// If there are no more baskets, restart the game.
		if (basketList.Count == 0) {
			SceneManager.LoadScene("_Scene_0");		// Reloading the scene essentially resets the game to the starting state.
		}

	}
}
