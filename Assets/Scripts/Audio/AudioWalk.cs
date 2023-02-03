using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioWalk : MonoBehaviour
{
    public float speed = 0.1f;

    private void Update()
    {
        if (Input.GetKey (KeyCode.RightArrow))
        {
            MoveRight();
            GetComponent<AudioSource>().UnPause();
           

        }
        else
        {
            GetComponent<AudioSource>().Pause();
        }

        void MoveRight()
        {
            Vector2 position = transform.position;
            position.x += speed;
            transform.position = position;
        }
    }


    /*void Start()
     {
         rb = GetComponent<Rigidbody2D>();
         audioSrc = GetComponent<AudioSource>();
     }

     // Update is called once per frame
     void Update()
     {
         dirX = Input.GetAxis("Horizontal") * moveSpeed;

         if (rb.velocity.x != 0)
             isMoving = true;
         else
             isMoving = false;

         if (isMoving)
         {
             if (!audioSrc.isPlaying)
                 audioSrc.Play();
         }
         else
             audioSrc.Stop();
     }

     void FixedUpdate()
     {
         rb.velocity = new Vector2(dirX, rb.velocity.y);
     }*/


    /*f (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
     {
         footstepsSound.enabled = true;
     }

     else
     {
         footstepsSound.enabled = false;
     }*/

}
