using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instructions : MonoBehaviour
{
    public GameObject instr;
    public GameObject softClick;

    private AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
        instr.SetActive(false);
        click = softClick.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show()
    {
        click.Play();
        instr.SetActive(true);
    }

    public void hide()
    {
        click.Play();
        instr.SetActive(false);
    }
}
