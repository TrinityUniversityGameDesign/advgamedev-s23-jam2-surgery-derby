using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganZone : MonoBehaviour
{
    public int organsInside;
    public SurgController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Organ o;
        if (collision.TryGetComponent<Organ>(out o))
        {
            organsInside++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Organ o;
        if (collision.TryGetComponent(out o))
        {
            organsInside--;
        }
    }
}
