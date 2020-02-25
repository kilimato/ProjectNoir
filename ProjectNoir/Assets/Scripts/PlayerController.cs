using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private float horizontalInput;
    private float verticalInput;

    public GameObject mainCircle;
    public GameObject secondaryCircle;
    public ClimbLadder climbLadder;

    public Animator animator;

    private Vector3 minSize = new Vector3(0.01f, 0.01f, 1);
    public GameObject playerLight;
    private Light2D lightRange;

    private SpriteRenderer sr;
    private bool facingRight;

    public GameObject lightPrefab;
    int timer = 0;


    void Start()
    {
        // we get the light by "using UnityEngine.Experimental.Rendering.Universal;"
        Light2D pLight = playerLight.GetComponent<Light2D>();
        lightRange = pLight;

        sr = GetComponent<SpriteRenderer>();
        facingRight = true;
    }
    // Update is called once per frame
    void Update()
    {
        PlayerMoves();
        CanPlayerClimb();

        IsMusicPlayed();
    }

    private void PlayerMoves()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;
        transform.position += movement;
        //transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);

        if(movement.x != 0)
        {
            sr.flipX = movement.x > 0f ? true : false;
        }

    }


    private void CanPlayerClimb()
    {
        if (climbLadder.CanPlayerClimb())
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            Vector3 movement = new Vector3(0f, verticalInput / 2, 0f) * speed * Time.deltaTime;
            transform.position += movement;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }


    public void IsMusicPlayed()
    {
        // tähän joku invoke repeating että valoja tulee tietyin aikavälein tmv.
        if (Input.GetKey(KeyCode.Space))
        {
            animator.SetBool("IsPlayingMusic", true);

            timer++;
            mainCircle.transform.localScale += new Vector3(0.1f, 0.1f, 0) * Time.deltaTime;
            secondaryCircle.transform.localScale += new Vector3(0.1f, 0.1f, 0) * Time.deltaTime;
            if (lightRange.pointLightInnerRadius < lightRange.pointLightOuterRadius - 0.1f)
                lightRange.pointLightInnerRadius += 0.01f;
            if (timer == 20)
            {
                Instantiate(lightPrefab, transform.position, transform.rotation);
                timer = 0;
            }


            if (lightRange.pointLightInnerRadius == lightRange.pointLightOuterRadius)
                return;
        }

        if (!Input.GetKey(KeyCode.Space) && (mainCircle.transform.localScale.x > 0.000001))
        {
            animator.SetBool("IsPlayingMusic", false);

            mainCircle.transform.localScale -= new Vector3(0.1f, 0.1f, 0) * Time.deltaTime;
            secondaryCircle.transform.localScale -= new Vector3(0.1f, 0.1f, 0) * Time.deltaTime;
            if (lightRange.pointLightInnerRadius > 0.1f)
                lightRange.pointLightInnerRadius -= 0.01f;
        }
    }
}
