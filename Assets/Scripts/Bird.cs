using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;


    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //is bird alive?
        if(isDead == false)
        {
            if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                rb2d.velocity = Vector2.zero;//either rising or falling, affect by gravity
                //inconsistant physics behavior
                //reset velocity to 0 
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }
#if UNITY_EDITOR
            if (Input.GetMouseButtonDown(0))//0 indicates left mouse click
            {
                rb2d.velocity = Vector2.zero;//either rising or falling, affect by gravity
                //inconsistant physics behavior
                //reset velocity to 0 
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
            }

#endif 

        }

    }

     void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();

    }
}
