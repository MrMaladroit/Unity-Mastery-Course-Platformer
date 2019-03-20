using System;
using UnityEngine;

public class CharacterGrounding : MonoBehaviour
{
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private float maxDistance = 0.1f;
    [SerializeField] private LayerMask layerMask;

    public bool IsGrounded { get; private set; }

    private void Update()
    {
        if (CheckGrounding(leftFoot))
        {
            IsGrounded = true;
        }
        else if (CheckGrounding(rightFoot))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
        
    }

    private bool CheckGrounding(Transform foot)
    {
        var raycastHit = Physics2D.Raycast(foot.position, Vector2.down, maxDistance, layerMask);

        if (raycastHit.collider != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}