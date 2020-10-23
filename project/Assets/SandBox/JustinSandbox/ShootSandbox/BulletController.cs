using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed;

    void Update()
    {
        //Move bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    //If collision with enemy deal damage to enemy and destory bullet
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //kill player
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}