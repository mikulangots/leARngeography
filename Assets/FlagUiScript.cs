using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagUiScript : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    private void OnEnable()
    {
        anim.SetTrigger("In");
    }
    public void SlideMeOut()
    {
        StartCoroutine("SlideOut");
    }
    IEnumerator SlideIn()
    {
        anim.SetTrigger("In");
        yield return new WaitForSeconds(1);
    }
    IEnumerator SlideOut()
    {
        anim.SetTrigger("Out");
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
