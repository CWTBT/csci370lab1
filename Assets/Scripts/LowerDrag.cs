using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerDrag : MonoBehaviour
{

    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D()
    {

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.drag = 0;

    }
}
