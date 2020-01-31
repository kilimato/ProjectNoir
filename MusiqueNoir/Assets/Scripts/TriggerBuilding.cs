using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBuilding : MonoBehaviour
{
    public GameObject interior;
    // Start is called before the first frame update
    void Start()
    {
        interior.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when player collides with this trigger, inside of the building is revealed
        interior.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //when player exit colliding with this trigger, inside of the building is hidden
        interior.SetActive(false);
    }


}
