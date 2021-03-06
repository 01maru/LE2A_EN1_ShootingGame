using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector3 LeftBottom;
    Vector3 RightTop;

    public float spd = 0.01f;

    //  ?q?p
    private float Left, Right, Top, Bottom;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in gameObject.transform)
        {
            if (child.localPosition.x >= Right)
            {
                Right = child.transform.localPosition.x;
            }
            if (child.localPosition.x <= Left)
            {
                Left = child.transform.localPosition.x;
            }
            if (child.localPosition.z >= Top)
            {
                Top = child.transform.localPosition.z;
            }
            if (child.localPosition.z <= Bottom)
            {
                Bottom = child.transform.localPosition.z;
            }
        }

        var distance = Vector3.Distance(Camera.main.transform.position, transform.position);

        LeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));

        RightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            pos.x += spd;
        }
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            pos.x -= spd;
        }
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            pos.z += spd;
        }
        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            pos.z -= spd;
        }

        transform.position = new Vector3(Mathf.Clamp(pos.x, LeftBottom.x + transform.localScale.x - Left, RightTop.x - transform.localScale.x - Right),
            pos.y,
            Mathf.Clamp(pos.z, LeftBottom.z + transform.localScale.z - Bottom, RightTop.z - transform.localScale.z - Top));
    }
}
