using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform holdParent;
    public float pickUpRange = 5;
    public float holdSag = .5f;
    public float moveForce = 250;
    public float maxMag = 3f;
    public GameObject heldObj;

    public Camera surgCam;
    [SerializeField] private LayerMask movableLayers;
    public void OnPickup()
    {
        if (heldObj == null)
        {
            RaycastHit2D hit = Physics2D.Raycast(surgCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.PositiveInfinity, movableLayers);   
            if (hit.rigidbody != null)
            {
                PickupObject(hit.transform.gameObject);
            }
        }
        else
        {
            DropObject();
        }


    }

    private void Update()
    {
        holdParent.position = surgCam.ScreenToWorldPoint(Input.mousePosition);
        if (heldObj != null)
        {
            MoveObject();
        }
    }


    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > holdSag) //only apply force if greater than sag distance
        {
            Vector3 move = ((holdParent.position) - heldObj.transform.position);
            Vector3 moveDir = move.normalized;
            float moveMag = move.magnitude - holdSag; //apply zero force at sag distance away from holder
            if (moveMag > maxMag) moveMag = maxMag;
            //add force at the center plus half of the colider's length
            heldObj.GetComponent<Rigidbody2D>().AddForceAtPosition(moveForce * moveMag * moveDir, heldObj.transform.position + (heldObj.transform.up * .5f));
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.TryGetComponent(out Rigidbody2D rb))
        {
            heldObj = pickObj;
            //rb.useGravity = false;
            rb.drag = 7.5f;
            rb.angularDrag = 2.5f;
            //rb.transform.parent = holdParent;
        }
    }

    void DropObject()
    {
        Rigidbody2D rb = heldObj.GetComponent<Rigidbody2D>();
        //rb.useGravity = true;
        rb.drag = 1;
        rb.angularDrag = 1;
        Vector3 tmp = rb.GetRelativePointVelocity(Vector3.zero);

        //heldObj.transform.parent = null;
        rb.velocity = tmp;
        heldObj = null;
    }
}
