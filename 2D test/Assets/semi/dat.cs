
using UnityEngine;
using System.Collections;

public class dat : MonoBehaviour {

	void Update (){

		Vector3 touchScreenPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,10.0f);
		Camera gameCamera = Camera.main;
		Vector3 touchWorldPosition = gameCamera.ScreenToWorldPoint (touchScreenPosition);
		this.transform.position = touchWorldPosition;

	}
}