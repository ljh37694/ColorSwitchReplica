using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public float jumpForce = 10f;
	private readonly string[] colorNames = new string[4] { "Blue", "Yellow", "Red", "Violet" };

	public Rigidbody2D rb;
	public SpriteRenderer sr;
	public Collider2D playerCol;

	private string currentColor;
	public Color[] colors = new Color[4];

	void Start() {
		SetRandomColor();
	}

	void Update() {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) {

			rb.velocity = Vector2.up * jumpForce;
		}
    }

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "ColorChanger") {
			SetRandomColor();

			Destroy(col.gameObject);
		}

		else if (col.tag ==  "Ground") {
			playerCol.isTrigger = false;
		}

		else if (Array.Exists(colorNames, x => x == col.tag) && currentColor != col.tag) {
			Debug.Log("Game Over!");

			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	private void OnCollisionExit2D(Collision2D collision) {
		playerCol.isTrigger = true;
	}

	void SetRandomColor() {
		int idx = UnityEngine.Random.Range(0, 4);

		currentColor = colorNames[idx];
		sr.color = colors[idx];
	}
}
