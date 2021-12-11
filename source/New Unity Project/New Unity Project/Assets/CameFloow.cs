using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameFloow : MonoBehaviour
{
    public Main main; 
    public Transform box;  
    Vector3 Dir; 
    
    public GameObject m_Player; 
    private Vector3 accelerate = Vector3.zero;  

    private float speed = 0.02f;  
  
    private bool rotateStart; 
    private bool canRoate = true;
    // Use this for initialization
    void Start()
    {
        Dir = m_Player.transform.position - transform.position; 
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (rotateStart)  
            return;

        if (main.direct == Vector3.left)
        {
            accelerate += new Vector3(-speed, 0, 0);
        }
        else if (main.direct == Vector3.down)
        {
            accelerate += new Vector3(0, -speed, 0);
        }
        else if (main.direct == Vector3.right)
        {
            accelerate += new Vector3(speed, 0, 0);
            if (Mathf.Abs(transform.position.x) <1 && canRoate)
            {
                canRoate = false;
                rotateStart = true;
                StartCoroutine(Rotate()); 
                main.pause = true;
            }
        }
        else if (main.direct == Vector3.up)
        {
            canRoate = true;
            accelerate += new Vector3(0, speed, 0);
        }

        transform.position = m_Player.transform.position - Dir + accelerate; 
        transform.LookAt(m_Player.transform.position); 
    }

    IEnumerator Rotate() 
    {
        rotateStart = true;
        float angle = 0;
        while (angle >= -178) 
        {
            angle -= 2f;
            Debug.Log(angle);
            box.rotation = Quaternion.Euler(0, angle, 0);
            yield return null;
        }
        box.rotation = Quaternion.Euler(0, -180, 0);
        rotateStart = false;
        main.pause = false;
    }
}
