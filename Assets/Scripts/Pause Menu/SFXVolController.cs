using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXVolController : MonoBehaviour
{
    public GameObject hitEnemy;
    public float hitEnemyMax = 0.7f;

    public GameObject grabMoney;
    public float grabMoneyMax = 0.7f;

    public GameObject bouncySurface;
    public float bouncyMax = 0.2f;

    public GameObject getHP;
    public float getHPMax = 0.7f;

    public GameObject negThump;
    public float negThumpMax = 0.4f;

    public GameObject softClick;
    public float softClickMax = 0.7f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // sliderVal = slider.GetComponent<Slider>().Value;
    }

    public void SFXVolume(float val)
    {
        // This feels excessive, but I want the volume to change relative to
        // the pre-configured balanced values
        hitEnemy.GetComponent<AudioSource>().volume = val * hitEnemyMax;
        grabMoney.GetComponent<AudioSource>().volume = val * grabMoneyMax;
        bouncySurface.GetComponent<AudioSource>().volume = val * bouncyMax;
        getHP.GetComponent<AudioSource>().volume = val * getHPMax;
        negThump.GetComponent<AudioSource>().volume = val * negThumpMax;
        softClick.GetComponent<AudioSource>().volume = val * softClickMax;
    }
}
