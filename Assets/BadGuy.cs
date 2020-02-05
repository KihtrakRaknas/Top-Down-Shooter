using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject child;
    void Start()
    {
        var exp = GetComponent<ParticleSystem>();
        exp.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*Time.deltaTime*3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var exp = GetComponent<ParticleSystem>();
        exp.Play();
        Destroy(child, exp.duration/5);
        Destroy(gameObject, exp.duration);
    }
}
