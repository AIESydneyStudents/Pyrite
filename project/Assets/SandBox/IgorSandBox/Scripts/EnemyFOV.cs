using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    public GameObject eyes;
    public GameObject player;
    float maxFOVAngle = 45f;
    float lookRadius = 8f;
    public Animator anim;
    bool canSeeYou;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        canSeeYou = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fovRadius = eyes.gameObject.transform.forward * lookRadius;
        float distanceToPlayer = Vector3.Distance(player.gameObject.transform.position - eyes.gameObject.transform.position, fovRadius);
        float playerAngle = Vector3.Angle(player.gameObject.transform.position - eyes.gameObject.transform.position, fovRadius);

        if(playerAngle < maxFOVAngle)
        {
            Debug.DrawRay(eyes.transform.position, player.transform.position);
            RaycastHit hit;
            if(Physics.Raycast(eyes.transform.position, player.transform.position, out hit))
            {
                if(hit.collider.CompareTag("Player"))
                {
                    anim.SetBool("CanSeeYou", true);
                    Debug.Log("Hitting Player");
                }
                else
                {
                    anim.SetBool("CanSeeYou", false);
                }

            }
        }

    }
}
