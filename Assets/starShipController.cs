using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starShipController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody ship;
    public Rigidbody missile;
    public GameObject rightMissile;
    public GameObject leftMissile;
    public GameObject enemy;
    Rigidbody last;
    Rigidbody secondLast;
    bool rightMissileFiredLast = false;
    float maxSpeed = 75;
    float decelerationRate = 50;
    float acelerationRate = 5000;
    void Start()
    {
        ship = GetComponent<Rigidbody>();
        InvokeRepeating("makeEnemy", 2.0f, 8.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ship.position = new Vector3(ship.position.x, 0, ship.position.z);


         this.transform.eulerAngles = new Vector3(
            0,
            0,
            -1*ship.velocity.x
        );

        if (ship.position.x > 70)
        {
            float addSpeed = (ship.position.x-70)*5;
            ship.AddForce(Vector3.left * (addSpeed + 5) * 100 * Time.deltaTime);
        }

        if (ship.position.x < -70)
        {
            float addSpeed = (ship.position.x + 70) * 5;
            ship.AddForce(Vector3.left * (addSpeed - 5) * 100 * Time.deltaTime);
        }

        if (ship.position.z > 35)
        {
            float addSpeed = (ship.position.z - 25) * 5;
            ship.AddForce(Vector3.forward * (addSpeed + 5) * -100 * Time.deltaTime);
        }

        if (ship.position.z < -35)
        {
            float addSpeed = (ship.position.z + 25) * 5;
            ship.AddForce(Vector3.forward * (addSpeed - 5) * -100 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow)){
            if(ship.velocity.z>-1* maxSpeed)
                ship.AddForce(Vector3.back * acelerationRate * Time.deltaTime);
        }else if (Input.GetKey(KeyCode.UpArrow)){
            if (ship.velocity.z < maxSpeed)
                ship.AddForce(Vector3.forward * acelerationRate * Time.deltaTime);
        }else{
            if (ship.velocity.z < 0)
                ship.AddForce(Vector3.back * ship.velocity.z  * decelerationRate * Time.deltaTime);
            else if (ship.velocity.z > 0)
                ship.AddForce(Vector3.back * ship.velocity.z * decelerationRate * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (ship.velocity.x > -1 * maxSpeed)
                ship.AddForce(Vector3.left * acelerationRate * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (ship.velocity.x < maxSpeed)
                ship.AddForce(Vector3.right * acelerationRate * Time.deltaTime);
        }
        else
        {
            if (ship.velocity.x < 0)
                ship.AddForce(Vector3.left * ship.velocity.x * decelerationRate * Time.deltaTime);
            else if (ship.velocity.x > 0)
                ship.AddForce(Vector3.left * ship.velocity.x * decelerationRate * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            var vec = rightMissile.transform.position;
            if (rightMissileFiredLast)
                vec = leftMissile.transform.position;
            if(secondLast)
             Debug.Log(secondLast.position.z - vec.z);
            if ((secondLast && secondLast.position.z > vec.z+5) ||!secondLast) { 
                rightMissileFiredLast = !rightMissileFiredLast;
                vec = new Vector3(vec.x, vec.y - 5, vec.z);
                Rigidbody clone = Instantiate(missile, vec, transform.rotation);
                vec = new Vector3(ship.velocity.x, 0, ship.velocity.z);
                clone.velocity = vec;
                clone.AddForce(Vector3.forward * 10, ForceMode.Impulse);
                secondLast = last;
                last = clone;
            }
        }
        
    }

    void makeEnemy()
    {
        var XoffSet = Random.Range(-60f, 60f); ;
        var YoffSet = 40;

        var pattern = Random.Range(0, 6);
        //pattern = 4;
        Debug.Log(pattern);
        if (pattern == 0) {
            GameObject instance = Instantiate(enemy);
            instance.transform.position = new Vector3(XoffSet + 10, -5f, YoffSet + 10);
            GameObject instance2 = Instantiate(enemy);
            instance2.transform.position = new Vector3(XoffSet, -5f, YoffSet + 10);
            GameObject instance3 = Instantiate(enemy);
            instance3.transform.position = new Vector3(XoffSet - 10, -5f, YoffSet + 10);
        }
        else if (pattern == 1)
        {
            GameObject instance7 = Instantiate(enemy);
            instance7.transform.position = new Vector3(XoffSet + 30, -5f, YoffSet + 0);
            GameObject instance5 = Instantiate(enemy);
            instance5.transform.position = new Vector3(XoffSet + 20, -5f, YoffSet + 5);
            GameObject instance1 = Instantiate(enemy);
            instance1.transform.position = new Vector3(XoffSet + 10, -5f, YoffSet + 10);
            GameObject instance2 = Instantiate(enemy);
            instance2.transform.position = new Vector3(XoffSet + 00, -5f, YoffSet + 5);
            GameObject instance3 = Instantiate(enemy);
            instance3.transform.position = new Vector3(XoffSet - 10, -5f, YoffSet + 10);
            GameObject instance4 = Instantiate(enemy);
            instance4.transform.position = new Vector3(XoffSet - 20, -5f, YoffSet + 5);
            GameObject instance6 = Instantiate(enemy);
            instance6.transform.position = new Vector3(XoffSet - 30, -5f, YoffSet + 0);
        }
        else if(pattern == 2){
            GameObject instance = Instantiate(enemy);
            instance.transform.position = new Vector3(XoffSet + 10, -5f, YoffSet + 10);
            GameObject instance2 = Instantiate(enemy);
            instance2.transform.position = new Vector3(XoffSet, -5f, YoffSet + 10);
            GameObject instance3 = Instantiate(enemy);
            instance3.transform.position = new Vector3(XoffSet - 10, -5f, YoffSet + 10);
            GameObject instance4 = Instantiate(enemy);
            instance4.transform.position = new Vector3(XoffSet - 20, -5f, YoffSet + 10);
            GameObject instance5 = Instantiate(enemy);
            instance5.transform.position = new Vector3(XoffSet + 20, -5f, YoffSet + 10);
        }
        else if (pattern == 3)
        {
            GameObject instance5 = Instantiate(enemy);
            instance5.transform.position = new Vector3(XoffSet + 20, -5f, YoffSet + 10);
            GameObject instance1 = Instantiate(enemy);
            instance1.transform.position = new Vector3(XoffSet + 10, -5f, YoffSet + 5);
            GameObject instance2 = Instantiate(enemy);
            instance2.transform.position = new Vector3(XoffSet + 00, -5f, YoffSet + 0);
            GameObject instance3 = Instantiate(enemy);
            instance3.transform.position = new Vector3(XoffSet - 10, -5f, YoffSet + 5);
            GameObject instance4 = Instantiate(enemy);
            instance4.transform.position = new Vector3(XoffSet - 20, -5f, YoffSet + 10);
        }
        else if (pattern == 4)
        {
            GameObject instance5 = Instantiate(enemy);
            instance5.transform.position = new Vector3(XoffSet + 20, -5f, YoffSet + 0);
            GameObject instance1 = Instantiate(enemy);
            instance1.transform.position = new Vector3(XoffSet + 10, -5f, YoffSet + 5);
            GameObject instance2 = Instantiate(enemy);
            instance2.transform.position = new Vector3(XoffSet + 00, -5f, YoffSet + 10);
            GameObject instance3 = Instantiate(enemy);
            instance3.transform.position = new Vector3(XoffSet - 10, -5f, YoffSet + 5);
            GameObject instance4 = Instantiate(enemy);
            instance4.transform.position = new Vector3(XoffSet - 20, -5f, YoffSet + 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        new WaitForSeconds(5);
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
