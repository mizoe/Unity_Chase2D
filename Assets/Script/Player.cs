using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// LR
		float x = Input.GetAxisRaw ("Horizontal");

		// Up down
		float y = Input.GetAxisRaw ("Vertical");

		// moving direction
		Vector2 direction = new Vector2 (x, y).normalized;
		
		// limit
		Move (direction);
	}

	// move the player
	void Move (Vector2 direction)
	{
		// 画面左下のワールド座標をビューポートから取得 get lower left (in world coordinate) from ViewPort
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		
		// 画面右上のワールド座標をビューポートから取得 get upper right (in world coordinate) from ViewPort
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		
		// プレイヤーの座標を取得 get the player position
		Vector2 pos = transform.position;
		// 移動量を加える add displacement
		pos += direction * this.speed * Time.deltaTime;
		
		// プレイヤーの位置が画面内に収まるように制限をかける not to over from the view
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		
		// 制限をかけた値をプレイヤーの位置とする set the player position as limited position calclated above
		transform.position = pos;
	}

}
