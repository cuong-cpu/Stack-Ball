using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float jumpSpeed;

    private Rigidbody rb;

    public float clickingSpeed;
    private bool clicking;
    private int Score;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            clicking = true;
            //Debug.Log("CLick");
        }

        else
        {
            clicking = false;
           // Debug.Log("No Click");
        }

        if (clicking)
        {
            rb.velocity = Vector3.down * clickingSpeed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (clicking)
        {
            if (collision.collider.gameObject.CompareTag("Bad"))
            {
                Time.timeScale = 0;
                SceneManager.LoadScene(2);
            }

            if (collision.collider.gameObject.CompareTag("Good"))
            {
                Score += 1;
                Destroy(collision.collider.transform.parent.gameObject);
                Debug.Log(Score);
            }
        }
        else
        {
            rb.velocity = Vector3.up * jumpSpeed;
        }

        if (collision.collider.gameObject.CompareTag("Floor"))
        {
            SceneManager.LoadScene(3);
        }
    }
}
