
/*limit2は、マウス・キーボード操作に対応している。キーボード操作はRigidbodyがなければ動かない
 * 
 *Spaceキー入力、またはエディタ上にある「Keyboad」のスイッチ変換で操作を切り替えられる
 *
 *limit2は、中心から目玉までの距離が指定以上になった場合、中心から「本来いた場所」まで線を引く
 *その長さが「指定距離」の点の座標を取得し、そこに目玉を移動させる
 */

using UnityEngine;
using System.Collections;

public class movelimit2 : MonoBehaviour {

	float speed = 5.0f;
	Vector3 center;//オブジェクトが出てはいけない円の中心座標
	Vector3 staypos;//オブジェクトがはみ出した時に、居させる座標
	LineRenderer line;
	public float hankei = 3.0f;
	bool keyboad = false;

	GameObject c4d;

	void Start(){
		this.center = new Vector3(2.0f, 1.0f);

		GameObject newline = new GameObject ("Line");
		this.line = newline.AddComponent<LineRenderer>();
		line.startWidth = 0.1f;
		line.endWidth = 0.1f;
		line.numPositions = 2;
	}

	void Update (){

		//キー操作処理
		if (Input.GetKeyDown (KeyCode.Space)) { keyboad = !keyboad; }

		//この部分は、マウス操作じゃなくても必要なのでとりあえず記載
		Vector3 touchScreenPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10.0f);

		Camera gameCamera = Camera.main;
		Vector3 touchWorldPosition = gameCamera.ScreenToWorldPoint (touchScreenPosition);

		if (keyboad) {
			float x = Input.GetAxisRaw ("Horizontal");
			float y = Input.GetAxisRaw ("Vertical");
			Vector2 direction = new Vector2 (x, y).normalized;
			GetComponent<Rigidbody2D> ().velocity = direction * speed;

		} else {
			this.transform.position = touchWorldPosition;
		}

		//①中心からの距離を求める部分
		Vector3 aePos = this.transform.position;
		float distance = Vector3.Distance(aePos,center);

		//距離から角度を算出
		float dx = aePos.x - this.center.x;
		float dy = aePos.y - this.center.y;
		float angle = Mathf.Atan2(dy, dx);

		//②Rayを定義する。
		//Ray searchray = new Ray(center,objectpos);
		//Ray searchray = new Ray(center, aePos);

		//③「hankei」の指定した距離の長さで、中点から現在のobject方向にRayを飛ばす。
		//   そこで距離分伸び切った「地点」の座標を取得し、stayposに代入
		//staypos = searchray.GetPoint (2.0f);
		//Vector3 boundaryPos = searchray.GetPoint(this.hankei);

		//中心点からcos,sin分だけ移動した座標を定義
		Vector3 stayPos = new Vector3(this.center.x + Mathf.Cos(angle)*this.hankei, this.center.y + Mathf.Sin(angle)*this.hankei, 10.0f);

		//④もし、中点からobjectまでの距離が「hankei」を越した時、。
		if (distance >= this.hankei) {
			this.transform.position = stayPos;
		}

		//Debug.DrawRay(center, fixedPos, Color.green);
		line.SetPosition (0, this.center);
		line.SetPosition (1, aePos);
		Debug.Log("centerは"+ center +  "objectは"+ aePos +"stayposは"+ stayPos);
		}
}