using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
	// Player prefab
	public GameObject enemy;
	public GameObject player;
	private GameObject _enemy;
	private float enemyVel = 2f;
	// Use this for initialization
	void Start () {
		InstantiateEnemy ();
	}
	
	// Update is called once per frame
	void Update () {
		//print ("_enemy:" + _enemy.transform.position);
		//print ("player:" + player.transform.position);

		//vector2 enemy > player
		Vector2 dir = -1 * _enemy.transform.position + player.transform.position;
		//print ("dir:" + dir.ToString());
		_enemy.rigidbody2D.velocity = dir.normalized * enemyVel; //normalize the direction vector, and get the velocity vector
	}

	public void InstantiateEnemy () {
		_enemy = Instantiate (enemy, enemy.transform.position, enemy.transform.rotation) as GameObject;
	}
}
