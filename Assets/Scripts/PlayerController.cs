using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    GameObject[] amountUps;

    private int count;

    private Rigidbody rb;

    void Start()
    {
        amountUps = GameObject.FindGameObjectsWithTag("Pick Up");
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontalmobile = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveVerticalmobile = CrossPlatformInputManager.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        Vector3 movementmobile = new Vector3(moveHorizontalmobile, 0.0f, moveVerticalmobile);

        rb.AddForce(movement * speed);
        rb.AddForce(movementmobile * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= amountUps.Length)
        {
            winText.text = "You win Boi!";
        }
    }
}