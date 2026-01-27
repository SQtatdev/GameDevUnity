using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
public class PlayerController : MonoBehaviour
{
    public float Speed;
    public TMP_Text ScoreText;
    public TMP_Text WinText;
    public GameObject Gate;
    private Rigidbody rb;
    public int Score;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Score = 0;
        SetScoreText();
        WinText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertival = Input.GetAxis("Vertical");

        Vector3 movement=new Vector3(moveHorizontal, 0.0f, moveVertival);

        rb.AddForce(movement * Speed);

        // Restart level 

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);    
        }

        // quit game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           Application.Quit(); 
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            Score++;
            SetScoreText();
            if (Score >= 5)
            {
                Gate.gameObject.SetActive(false);
            }
        }
        if (other.gameObject.CompareTag("danger"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void SetScoreText()
    {
        ScoreText.text="Score: " + Score.ToString();

        if(Score == 10)
        {
            WinText.text = "You win";
        }
    }
    
}
