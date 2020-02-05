using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletGoForward : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody bullet;
    float decelerationRate = 50;
    public GameObject mis;
    void Start()
    {
        bullet = GetComponent<Rigidbody>();
        var exp = mis.GetComponent<ParticleSystem>();
        exp.Stop();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bullet.AddForce(Vector3.forward * 500, ForceMode.Force);

        if (bullet.velocity.x < 0)
            bullet.AddForce(Vector3.left * bullet.velocity.x * decelerationRate * Time.deltaTime);
        else if (bullet.velocity.x > 0)
            bullet.AddForce(Vector3.left * bullet.velocity.x * decelerationRate * Time.deltaTime);

        if(bullet.position.z>50)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "missile")
        {
            Debug.Log("hit");
            var exp = mis.GetComponent<ParticleSystem>();
            exp.Play();
            Destroy(gameObject);
        }
    }
}
