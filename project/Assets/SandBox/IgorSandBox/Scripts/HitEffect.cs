using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    private ParticleSystem partSys;

    //private IgorMov playMov;

    // Start is called before the first frame update
    void Start()
    {
        partSys = GetComponent<ParticleSystem>();
       // playMov = GameObject.FindGameObjectWithTag("Player").GetComponent<IgorMov>();

    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (playMov.isGroundSlamming)
    //        partSys.Play();
    //}

    public void HitEffectPlay()
    {
        partSys.Play();
    }
}
