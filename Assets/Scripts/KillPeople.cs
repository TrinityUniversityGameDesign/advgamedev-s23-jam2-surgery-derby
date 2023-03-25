using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPeople : MonoBehaviour
{
    public Scores player;
    Rigidbody rb;
    Vector3 startPos;
    Quaternion startRot;
    public void Start(){
        rb = GetComponent<Rigidbody>();
        startPos = rb.position;
        startRot = rb.rotation;
    }
    public void OnTriggerEnter(Collider collide){
        if(collide.gameObject.tag == "car"){
            Rigidbody friend = collide.GetComponentInParent<Rigidbody>();
            isHit(collide.transform.forward, friend.velocity);
        }
    }

    void isHit(Vector3 dir,Vector3 vel){
        GetComponent<Collider>().enabled = false;
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
        float x = dir.x * vel.x +5;
        float y = dir.y * vel.y +5;
        float z = dir.z * vel.z +5;
        rb.velocity = new Vector3(x,y,z);
        rb.AddTorque(Random.Range(-0.1f, 0.1f),Random.Range(-0.1f, 0.1f),Random.Range(-0.1f, 0.1f));
        StartCoroutine(HitThenDie());
        StopCoroutine(HitThenDie());
		}
    private IEnumerator HitThenDie() {
        yield return new WaitForSeconds(6);
        player.addtoscore();
        Destroy(this.gameObject);
    }
}
