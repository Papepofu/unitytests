

/*limitでは、原則としてキーボード入力を受け付けている
 *だが、Spaceキー入力、またはエディタ上にある「Keyboad」のスイッチ変換で操作を切り替えられる
 *
 *limitは、半径を超えた瞬間、超えた位置を記憶し、超えている間はその位置にオブジェクトを留め続ける働きをする。
 *マウス入力よりはキーボード向きかも
 */

using UnityEngine;
using System.Collections;

public class movelimit : MonoBehaviour {

	float speed = 5.0f;
	public Vector3 center = new Vector3(0.0f,0.0f,0.0f); 
	public float hankei = 1.0f;
	public Vector3 staypos = new Vector3(0,0,0);
	bool over = false;
	bool keyboad = true;


	// Use this for initialization
	void Start () {

	}
		

	void Update (){

		if (Input.GetKeyDown (KeyCode.Space)) { keyboad = !keyboad; }

		if (keyboad) {

			float x = Input.GetAxisRaw ("Horizontal");
			float y = Input.GetAxisRaw ("Vertical");
			Vector2 direction = new Vector2 (x, y).normalized;
			GetComponent<Rigidbody2D> ().velocity = direction * speed;

		} else {
			
			Vector3 touchScreenPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 20);

			touchScreenPosition.x = Mathf.Clamp (touchScreenPosition.x, 0.0f, Screen.width);
			touchScreenPosition.y = Mathf.Clamp (touchScreenPosition.y, 0.0f, Screen.height);
			touchScreenPosition.z = 10.0f;

			Camera gameCamera = Camera.main;
			Vector3 touchWorldPosition = gameCamera.ScreenToWorldPoint (touchScreenPosition);
			this.transform.position = touchWorldPosition;
		}

		//中心からの距離を求める部分
		Vector3 Aepos = this.transform.position;
		float disdis = Vector3.Distance(Aepos,center);
		//Debug.Log ("中点からの距離は" + disdis);


		if (disdis >= hankei) {//越した時の処理
			if (over == false) {staypos = this.transform.position;
								over = true;}
			
			else if(over == true){this.transform.position = staypos;}
		}
		if(disdis < hankei){
				over = false;
			}

		Debug.Log (over);

		} 
		
}