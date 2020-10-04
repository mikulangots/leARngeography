using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc : MonoBehaviour
{
    Renderer rend;
    public string stateName;
    public Animator flagDown;
    public Transform canvas, cameraRig;
    void Start()
    {
        rend = this.GetComponent<Renderer>();
    }
    void Update()
    {
        canvas.rotation = cameraRig.transform.rotation;
    }
     void OnMouseDown()
    {
        if (GameController.instance.ClickFlag(stateName))
        {
            rend.material.SetColor("_Color", Color.green);
            flagDown.SetTrigger("DropFlag");
        }
    }
}
