using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text loseText;
    public Text scoreText;
    public Text livesText;
    public GameObject Ramp;


    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        score = 0;
        SetScoreText();
        lives = 3;
        SetLivesText();
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();

        if (count >= 11)
        {
            Ramp.gameObject.SetActive(true);   
        }

        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetCountText();
            SetScoreText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
        
            score = score - 1;
            lives = lives - 1;
            SetLivesText();
            SetScoreText();
        }
    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score >= 21)
        {
            winText.text = "Victory!";
        }
    }

    void SetLivesText()
    {
        livesText.text = "lives: " + lives.ToString();
        if (lives <= 0)
        {
            loseText.text = "Defeat!";
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();      
    }
}
