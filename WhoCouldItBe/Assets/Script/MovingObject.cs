using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public LayerMask layerMask;
    public float speed;
    public int walkCount;
    protected int currentWalkCount;

    protected Vector3 vector;
    public Animator animator;

}