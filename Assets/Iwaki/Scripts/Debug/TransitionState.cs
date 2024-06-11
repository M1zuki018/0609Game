using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TransitionState : MonoBehaviour
{
    public bool drag, drop;
    TakinokoAnimation animator;
    private void Start()
    {
        animator = GetComponent<TakinokoAnimation>();
    }
    void Update()
    {
        if (drag)
        {
            animator.StartDrag();
            drag = false;
        }
        if (drop)
        {
            animator.StartDrop();
            drop = false;
        }
    }
}
