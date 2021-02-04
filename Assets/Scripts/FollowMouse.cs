using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    //https://answers.unity.com/questions/409985/add-force-towards-inputmouseposition-position-not.html
    // Manipulates the platform's velocity instead of just transforming it.
    // AddForce didn't work for some reason so directly changed velocity instead.
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = pos - transform.position;
        direction.y = 0;
        rb.velocity = direction.normalized * 10000 * Time.deltaTime;
        Debug.Log("Direction: " + rb.velocity);

    }
}
