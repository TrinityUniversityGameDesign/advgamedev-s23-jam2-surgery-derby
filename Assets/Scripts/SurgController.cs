using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurgController : MonoBehaviour
{
    public Pickup picker;
    public List<GameObject> organs;

    public List<GameObject> organPrefabs;
    public OrganZone zone;

    public GameObject loadzone;
    private void Start()
    {

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            picker.OnPickup();
        }
        if (Input.GetMouseButtonDown(1))
        {
            SpawnOrgan();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("score: " + zone.organsInside);
            foreach (var item in organs)
            {
                Destroy(item);
            }
            organs.Clear();
            zone.organsInside = 0;
        }

    }

    public void SpawnOrgan()
    {
        organs.Add(Instantiate(organPrefabs[Random.Range(0, organPrefabs.Count - 1)], loadzone.transform.position, Quaternion.identity));
    }
}
