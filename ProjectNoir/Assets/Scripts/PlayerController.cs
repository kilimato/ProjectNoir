using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private float horizontalInput;
    private float verticalInput;

    public GameObject mainCircle;
    public GameObject secondaryCircle;

    private Vector3 minSize = new Vector3(0.01f, 0.01f, 1);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoves();

        IsMusicPlayed();
    }

    private void PlayerMoves()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        transform.position += movement;
        //transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);

        // flips the player sprite to face to the right direction
        if (movement.x >= 0.01f)
        {
            transform.localScale = new Vector3(2.5f, 2.5f, 1f);
        }
        else if (movement.x <= -0.01f)
        {
            transform.localScale = new Vector3(-2.5f, 2.5f, 1f);
        }

    }

    public void IsMusicPlayed()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            mainCircle.transform.localScale += new Vector3(0.1f, 0.1f, 0) * Time.deltaTime;
            secondaryCircle.transform.localScale += new Vector3(0.1f, 0.1f, 0) * Time.deltaTime;
        }

        if (!Input.GetKey(KeyCode.Space) && (mainCircle.transform.localScale.x > 0.000001))
        {
            mainCircle.transform.localScale -= new Vector3(0.1f, 0.1f, 0) * Time.deltaTime;
            secondaryCircle.transform.localScale -= new Vector3(0.1f, 0.1f, 0) * Time.deltaTime;
        }
    }

    // tee laskeutuminen portaita alas: nyt menee alas mistä tahansa kohtaa lattiaa,
    // tee niin että kun onTriggerstay portaissa, ignooraa collisionin lattian kanssa
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder") && Input.GetKey(KeyCode.S))
        {
            Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Platform").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Platform").GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>(), false);
    }
}
