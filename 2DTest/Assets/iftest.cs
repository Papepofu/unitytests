using UnityEngine;
using System.Collections;
	
public class Player {
	public int hp = 100;
	private int power = 50;

	public void Attack(){
		Debug.Log (this.power + "のダメージを与えた");
	}

	public void Damage(int damage){
		this.hp -= damage;
		Debug.Log (damage + "のダメージを受けた");
	}

	public void lasthp(){
		Debug.Log ("残りのHPは" + this.hp);
	}
}
	

public class iftest : MonoBehaviour {

	// Use this for initialization

	void Start () {
		Player PlayerA = new Player ();

		PlayerA.Attack ();
		PlayerA.Damage (30);
		Debug.Log ("プレイヤーの残り体力は" + PlayerA.hp);
	}

	// Update is called once per frame
	void Update () {
	
	
	}
}

