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

    private Vector3 minSize = new Vector3(0.15f, 0.15f, 1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        //transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);

        IsMusicPlayed();
    }

    public void IsMusicPlayed()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            mainCircle.transform.localScale += new Vector3(0.1f,0.1f,0) * Time.deltaTime;
            secondaryCircle.transform.localScale += new Vector3(0.1f, 0.1f, 0) * Time.deltaTime;
        }

        if (! Input.GetKey(KeyCode.Space) && (mainCircle.transform.localScale.x > 0.05))
        {
            mainCircle.transform.localScale -= new Vector3(0.1f, 0.1f, 0) * Time.deltaTime;
            secondaryCircle.transform.localScale -= new Vector3(0.1f, 0.1f, 0) * Time.deltaTime;
        }
    }
}
