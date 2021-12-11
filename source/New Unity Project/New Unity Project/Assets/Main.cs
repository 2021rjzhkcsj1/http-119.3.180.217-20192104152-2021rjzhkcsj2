using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Vector3 direct;
    public bool pause;
    // Start is called before the first frame update
    void Start()
    {
        direct = Vector3.left;
    }

    void Update()
    {
        if (pause)
            return;
        transform.Translate(direct * Time.deltaTime, Space.World);

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.name) 
        {
            case "1":
                direct = Vector3.down;
                break;
            case "2":
                direct = Vector3.left;
                break;
            case "3":
                direct = Vector3.up;
                break;
            case "4":
                direct = Vector3.right;
                break;
        }
    }
}
