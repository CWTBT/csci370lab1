using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPancakes : MonoBehaviour
{

    public GameObject pancake;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DropPancake2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 
    IEnumerator DropPancake2()
    {
        yield return new WaitForSeconds(2f);
        for (; ; )
        {
            Instantiate(pancake);

            pancake.transform.position = new Vector2(Random.Range(-3, 3),pancake.transform.position.y);

            yield return new WaitForSeconds(2.5f);
        }
    }
}
