using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    [SerializeField] Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            transform.position = hit.point;
        }*/

        transform.position = GetMousePos();
    }

    public Vector3 GetMousePos()
    {
        Vector3 myPos = Input.mousePosition;
        myPos = new Vector3(myPos.x, myPos.y, 8f);
        return cam.ScreenToWorldPoint(myPos);
    }
}
