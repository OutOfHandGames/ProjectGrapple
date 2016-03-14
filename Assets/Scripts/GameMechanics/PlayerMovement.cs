using UnityEngine;
using System.Collections;

public class PlayerMovement : Movement {
	
	// Update is called once per frame
	void Update () {
        updateHInput(Input.GetAxisRaw("Horizontal"));
        updateVInput(Input.GetAxisRaw("Vertical"));
	}
}
