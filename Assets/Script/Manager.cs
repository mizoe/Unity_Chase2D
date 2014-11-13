using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour {
	// Player prefab
	public GameObject follower;
	public GameObject forceFollower;
	public float controlGainP = 1f;
	public float controlGainD = 1f;
	public GameObject player;
	public GameObject enemy;   //prefab
	private GameObject _enemy; //instance
	private List<GameObject> _followers = new List<GameObject>(); // list of instance
	private List<GameObject> _fFollowers = new List<GameObject>(); // list of instance
	private float followerVel = 5f;
	public float followerDistance = 1f;
	public int maxFollowers = 4;
	// Use this for initialization
	void Start () {
		buildInstance ();
		// set the folloer speed same as the player
		followerVel = Player.speed; //public static
	}
	
	// Update is called once per frame
	void Update () {
		for(int i=0; i<maxFollowers; i++) {
			//print ("_followers[i]:" + _followers[i].transform.position);
			//print ("player:" + player.transform.position);

			/* 
			 * Velocity Follower 
			 */
			//vector2 follower[i] > (player or follower[i-1])
			Vector2 dir;
			if(i==0)
				dir = -1 * _followers[i].transform.position + player.transform.position;
			else
				dir = -1 * _followers[i].transform.position + _followers[i-1].transform.position;
			//print ("dir:" + dir.ToString());

			// move the follower by velocity if the distance was over followerDistance
			if(dir.magnitude > followerDistance)
				_followers[i].rigidbody2D.velocity = dir.normalized * followerVel; //normalize the direction vector, and get the velocity vector
			else
				_followers[i].rigidbody2D.velocity = new Vector2(0f,0f);

			/* 
			 * Force Follower 
			 */
			//vector2 follower[i] > (player or follower[i-1])
			Vector2 fDir; // vector from follower[i] to navigator
			Vector2 navigator;
			if(i==0)
				navigator = (Vector2)player.transform.position;
			else
				navigator = (Vector2)_fFollowers[i-1].transform.position;
			fDir = -1 * (Vector2)_fFollowers[i].transform.position + navigator;
			//print ("dir:" + dir.ToString());

			// target point which is on the circumference of the player
			Vector2 target = navigator - fDir.normalized * followerDistance;
			// move the follower by velocity if the distance was over followerDistance+1
			Vector2 difference = _fFollowers[i].rigidbody2D.position - target;
			// get the control force as PI controller
			Vector2 force = - _fFollowers[i].rigidbody2D.velocity * controlGainD - difference * controlGainP;
			// add the control force
			_fFollowers[i].rigidbody2D.AddForce(force);
		}
		Vector2 enemyToPlayer = -1 * _enemy.transform.position + player.transform.position;
		_enemy.rigidbody2D.velocity = enemyToPlayer.normalized * followerVel * 0.5f; //normalize the direction vector, and get the velocity vector
	}
	
	public void buildInstance () {
		for (int i=0; i<maxFollowers; i++) {
			_followers.Add(Instantiate (follower, follower.transform.position, follower.transform.rotation) as GameObject);
		}
		for (int i=0; i<maxFollowers; i++) {
			_fFollowers.Add(Instantiate (forceFollower, forceFollower.transform.position, forceFollower.transform.rotation) as GameObject);
		}
		_enemy = Instantiate (enemy, enemy.transform.position, enemy.transform.rotation) as GameObject;
	}
}
