using System;
using UnityEngine;

public class UICoinPulse : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameManager.instance.OnCoinsChanged += HandleOnCoinsChanged;
    }

    private void HandleOnCoinsChanged(int coins)
    {
        animator.SetTrigger("Pulse");
    }
}