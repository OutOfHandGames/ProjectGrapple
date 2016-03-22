using UnityEngine;
using System.Collections;

public class ModelAnimator : MonoBehaviour {
    Animator anim;
    Movement movement;


    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        anim.SetFloat("Speed", movement.getSpeed());
    }
}
