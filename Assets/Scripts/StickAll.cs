using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickAll : MonoBehaviour
{

    bool isStuck = false;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isStuck) return;
        else
        {
            isStuck = true;
            //StopMovement(collision);
            ArrayList pieces = GetPieces(collision);
            InitJoint(pieces);
        }
    }

    private ArrayList GetPieces(Collision2D collision)
    {
        ArrayList pancakeSections = new ArrayList();

        GameObject parent = collision.gameObject.transform.parent.gameObject;
        for (int i = 0; i < 3; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            pancakeSections.Add(child);
        }

        return pancakeSections;
    }

    private void InitJoint(ArrayList pieces)
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject child = pieces[i] as GameObject;
            SpringJoint2D joint = child.AddComponent(typeof(SpringJoint2D)) as SpringJoint2D;

            rb = this.gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            joint.connectedBody = rb;

            joint.distance = 0.1f;
            joint.autoConfigureDistance = false;
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = new Vector2(0f, 0.8f);
            joint.dampingRatio = 0.9f;
            joint.frequency = 0f;
            //joint.breakForce = 100;
        }
    }
}
