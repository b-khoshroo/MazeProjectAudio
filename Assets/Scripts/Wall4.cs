using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall4 : MonoBehaviour
{
    AudioSource wall4_audioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //A simple echolocating:

        //if the left shift key (or X button) is pressed, if the player is on the right, that is, the wall is
        //on the left of the player no further than 10 units away, the wall generates a sound with
        //a delay proportionate to where the player is
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton2))
        {

            if ((GameObject.Find("Player").transform.position.x > transform.position.x)
                && (GameObject.Find("Player").transform.position.x < transform.position.x + 3))
            {

                float distanceFromPlayer = Math.Abs(transform.position.x - GameObject.Find("Player").transform.position.x);
                float delay = distanceFromPlayer / 5;

                StartCoroutine(playSoundWithDelay(delay));
            }

        }

        //In the same way, if the right shift key (or B button) is pressed, it is checked if the wall is on the right side of
        //the player.
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.JoystickButton1))
        {

            if ((GameObject.Find("Player").transform.position.x < transform.position.x)
                && (GameObject.Find("Player").transform.position.x > transform.position.x - 3))
            {

                float distanceFromPlayer = Math.Abs(transform.position.x - GameObject.Find("Player").transform.position.x);
                float delay = distanceFromPlayer / 5;

                StartCoroutine(playSoundWithDelay(delay));
            }

        }


    }

    //generting a sound on collision with the player
    private void OnCollisionEnter(Collision collision)
    {
        //If we wanted to see with which we/the cube has been collided: collision.collider

        if (collision.collider.name == "Player")
        {
            wall4_audioSource = GetComponent<AudioSource>();
            wall4_audioSource.Play();

        }
    }

    IEnumerator playSoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        wall4_audioSource = GetComponent<AudioSource>();
        wall4_audioSource.Play();
    }
}
