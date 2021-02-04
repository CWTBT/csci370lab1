using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeStick3 : MonoBehaviour
{

    bool isStuck = false;
    SpringJoint2D joint;
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
            GameObject last = GetLastPiece(collision);

            joint = last.AddComponent(typeof(SpringJoint2D)) as SpringJoint2D;

            rb = this.gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            joint.connectedBody = rb;

            joint.distance = 0.1f;
            joint.autoConfigureDistance = false;
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor.Set(3.679737e-09f, 0.815f);
            joint.dampingRatio = 0.9f;
            joint.frequency = 0f;
            //joint.breakForce = 100;
        }
    }
    private GameObject GetLastPiece(Collision2D collision)
    {
        GameObject parent = collision.gameObject.transform.parent.gameObject;
        return parent.transform.GetChild(2).gameObject;
    }

    private void StopMovement(Collision2D collision)
    {
        GameObject parent = collision.gameObject.transform.parent.gameObject;

        //https://forum.unity.com/threads/iterating-child-game-objects-in-c.22860/
        //https://forum.unity.com/threads/stop-a-moving-object-how.94390/
        foreach (Transform child in parent.transform)
        {
            Rigidbody2D crb = child.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
            crb.velocity = Vector2.zero;
        }
    }
}
