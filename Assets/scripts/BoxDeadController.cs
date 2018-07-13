using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDeadController : MonoBehaviour {

    public bool active;
    public GameObject skull;
    public int id;


    private void Update()
    {
        skull.SetActive(active);
    }
}
