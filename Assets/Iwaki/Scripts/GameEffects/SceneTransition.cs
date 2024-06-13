using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    Animator transitionAnimator;
    [SerializeField] UnityEvent startEvent;
    private void Start()
    {
        transitionAnimator = GetComponent<Animator>();
        startEvent.Invoke();
    }

    public void InTransition()
    {
        transitionAnimator.SetTrigger("In");
    }

    public void OutTransition()
    {
        transitionAnimator.SetTrigger("Out");
    }
}
