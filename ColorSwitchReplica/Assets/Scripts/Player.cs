using UnityEngine;

public class Player : MonoBehaviour
{
	public float jumpForce = 10f;
	private readonly string[] colorNames = new string[4] { "Blue", "Yellow", "Red", "Violet" };

	public Rigidbody2D rb;
	public SpriteRenderer sr;

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
		Debug.Log(col.tag);
	}

	void SetRandomColor() {
		int idx = Random.Range(0, 3);

		currentColor = colorNames[idx];
		sr.color = colors[idx];
	}
}
