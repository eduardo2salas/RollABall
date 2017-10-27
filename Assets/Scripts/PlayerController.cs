using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public AudioSource audio;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

    void Start() {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false);
            audio.Play();
            count++;
            SetCountText();
        }
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString();
        if(count >= 12) {
            winText.text = "You Win";
        }
    }
}