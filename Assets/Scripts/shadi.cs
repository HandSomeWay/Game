using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadi : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            animator.SetTrigger("xianru");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            animator.SetTrigger("taisheng");
    }
}
