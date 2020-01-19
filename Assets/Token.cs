using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    public int Type;
    public bool dragging;
    public Cell HostCell;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dragging == true)
        {
            Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 tokenposition = new Vector3(mouseposition.x, mouseposition.y, -1.5f);
            this.transform.position = tokenposition;
        }
        else
        {
            this.transform.position = HostCell.transform.position;
        }
    }
}
