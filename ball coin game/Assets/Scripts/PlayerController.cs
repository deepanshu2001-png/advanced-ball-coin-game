using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce = 3.0f;
    public float maxJumpForce = 15.0f;
    public float jumpChargeRate = 3.0f;
    private float jumpTimer = 0.0f;
    float xInput;
    float yInput;
    public AudioSource audioPlayer;

    Rigidbody rb;
    
    int CoinsCollected;

    public GameObject WinText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (transform.position.y <= -8f)
        {
            SceneManager.LoadScene(0);
        }

          if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpTimer = 0.0f;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            jumpTimer += Time.deltaTime;
            jumpForce = Mathf.Clamp(jumpTimer * jumpChargeRate, jumpForce, maxJumpForce);
        }

        if (Input.GetKeyUp(KeyCode.Space) && jumpTimer > 0.0f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpTimer = 0.0f;
        }
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(xInput * moveSpeed, 0, yInput * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            CoinsCollected++;
            audioPlayer.Play();

            other.gameObject.SetActive(false);
        

        }
        
        if (CoinsCollected >= 16)
        {
            WinText.SetActive(true);

        }
    }
}
