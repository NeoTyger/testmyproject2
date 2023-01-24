using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ItemMsg();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void ItemMsg()
    {
        Debug.Log("Item Message");
    }
}
