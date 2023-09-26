using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour
{
    public BoxCollider2D box;
    public BoxCollider2D box2;
    // Start is called before the first frame update
    void Start()
    {
        box.isTrigger = true;
        Invoke("a", 2);
    }

    private void a()
    {
        box.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
