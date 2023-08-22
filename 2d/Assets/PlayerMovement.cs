using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D a;
    private Animator anime;
    private BoxCollider2D coll;
    private SpriteRenderer sp;
    private float x =0f;
    public bool isJumping=false;//jumping true means jumping false means not jumping
    private enum MovementState{idle,running,jumping,falling};
    [SerializeField]private LayerMask jumpableGround;
    // Start is called before the first frame update
    void Start()
    {
        a=GetComponent<Rigidbody2D>();
        anime=GetComponent<Animator>();
        sp=GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x =Input.GetAxis("Horizontal");
        a.velocity=new Vector2(x * 7f,a.velocity.y);
        if(Input.GetKeyDown("space") && IsGrounded()){
            a.velocity=new Vector2(a.velocity.x,14);
            isJumping=true;
        }
        // AnimeUpdate();
        MovementState state;
        if(x > 0f){
            state = MovementState.running;
            sp.flipX=false;
        }
        else if(x < 0f){
            state = MovementState.running;
            sp.flipX=true;
        }
        else{
            state = MovementState.idle;
        }
        if(a.velocity.y> .1f){
            state=MovementState.jumping;
        }
        else if(a.velocity.y<-.1f){
            state=MovementState.falling;
        }
        anime.SetInteger("state",(int)state);
    }
    // private void AnimeUpdate(){
    //     MovementState state;
    //     if(x > 0f){
    //         state = MovementState.running;
    //         sp.flipX=false;
    //     }
    //     else if(x < 0f){
    //         state = MovementState.running;
    //         sp.flipX=true;
    //     }
    //     else{
    //         state = MovementState.idle;
    //     }
    //     if(a.velocity.y> .1f){
    //         state=MovementState.jumping;
    //     }
    //     else if(a.velocity.y<-.1f){
    //         state=MovementState.falling;
    //     }
    //     anime.SetInteger("state",(int)state);
    // }
    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f, Vector2.down,.1f,jumpableGround);
    }
}

