using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
             other.GetComponent<Enemy>().Damage();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        pos.z += 0.5f;
        transform.position = new Vector3(pos.x, pos.y, pos.z);

        if (pos.z >= 20)
        {
            Destroy(this.gameObject);
        }
    }
}
