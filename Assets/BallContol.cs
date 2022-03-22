using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallContol : MonoBehaviour
{

    public Camera camera;
    public Rigidbody rigidbody;

    public int counter = 0;

    public Text counterText;
    public Text gameFinished;
    public Text restartText;

    private bool isGameFinished = false;

    // Start is called before the first frame update
    void Start() {
        gameFinished.text = "";
        counterText.text = "Score: " + counter;
        restartText.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if(!isGameFinished)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 vec = new Vector3(horizontal, 0, vertical);

            camera.transform.position = transform.position + new Vector3(0, 2, -6);

            rigidbody.AddForce(vec * 0.2f, ForceMode.Impulse);

            if (Input.GetKeyDown(KeyCode.Space))
                rigidbody.AddForce(new Vector3(0, 15, 0), ForceMode.Impulse);
        }

        if(isGameFinished && Input.GetKeyDown(KeyCode.F)) {
            SceneManager.LoadScene("SampleScene");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "collactable")
        {
            other.gameObject.SetActive(false);
            Debug.Log("Counter:" + ++counter);

            counterText.text = "Score: " + counter;

            if (counter == 5)
            {
                gameFinished.text = "Game Finished";
                isGameFinished = true;
                restartText.enabled = true;
            }
        }

    }
}
