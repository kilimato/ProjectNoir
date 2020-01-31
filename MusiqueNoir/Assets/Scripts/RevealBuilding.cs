using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealBuilding : MonoBehaviour
{
    public GameObject player;
    public BoxCollider2D entrance;
    public GameObject building;
    // Start is called before the first frame update
    void Start()
    {
        building.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when player collides with this trigger, inside of the building is revealed
        building.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //when player exit colliding with this trigger, inside of the building is hidden
    }
}
