using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float spd = 1;
    public float time = 50;

    protected Vector3 forward = new Vector3(1, 1, 1);

    protected Quaternion forwardAxis = Quaternion.identity;

    protected Rigidbody rb;
    protected GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "PlayerBody")
        {
            UIController.SubPlayerHP();
            Destroy(this.gameObject);
        }
    }
    public void SetCharacterObject(GameObject character)
    {
        this.enemy = character;
    }
    public void SetForwardAxis(Quaternion axis)
    {
        this.forwardAxis = axis;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        if (enemy != null)
        {
            forward = enemy.transform.forward;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = forwardAxis * forward * spd;

        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        time -= Time.deltaTime;

        if (time <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
