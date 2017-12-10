using UnityEngine;
using System.Collections;

public class move3D : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public float speed = 5;
	// Update is called once per frame
	void Update () {
		// 右・左
		float x = Input.GetAxisRaw ("Horizontal");

		// 上・下
		float y = Input.GetAxisRaw ("Vertical");

		// 移動する向きを求める
		Vector3 direction = new Vector3 (x, y).normalized;

		// 移動する向きとスピードを代入する
		GetComponent<Rigidbody>().velocity = direction * speed;
	}
}
