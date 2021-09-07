﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MovingObject
{
    static public PlayerManager instance;

    public string currentMapName;
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    IEnumerator MoveCoroutine()
    {
        while (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

                if (vector.x != 0)
                    vector.y = 0;

                animator.SetFloat("Dirx", vector.x);
                animator.SetFloat("Diry", vector.y);

                RaycastHit2D hit;

                Vector2 start = transform.position;
                Vector2 end = start + new Vector2(vector.x * speed * walkCount, vector.y * speed * walkCount);

                boxCollider.enabled = false;
                hit = Physics2D.Linecast(start, end, layerMask);
                boxCollider.enabled = true;

                if (hit.transform != null)
                    break;

                animator.SetBool("Walking", true);

                while (currentWalkCount < walkCount)
                {
                    if (vector.x != 0)
                    {
                        transform.Translate(vector.x * speed, 0, 0);

                    }
                    else if (vector.y != 0)
                    {
                        transform.Translate(0, vector.y * speed, 0);
                    }

                    currentWalkCount++;
                    yield return new WaitForSeconds(0.01f);
                }

                currentWalkCount = 0;


            }
        }
        animator.SetBool("Walking", false);
        canMove = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                canMove = false;
                StartCoroutine(MoveCoroutine());
            }
        }


    }
}
