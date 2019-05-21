using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller2D : MonoBehaviour
{
    #region Public Variables
    public float moveSpeed;
    #endregion
    #region Private Variables
    private GameObject spawner;
    private GameObject tool;
    private GameObject cursor;
    private GameObject cam;
    private Animator anim;
    private Rigidbody2D rb;
    private Transform pivotPoint;
    private Vector2 move;
    private Vector3 mousePosition;
    private float toolYScale;
    private bool turn = false;
    #endregion

    private void Start()
    {
        spawner = GameObject.FindWithTag("PlayerBulletSpawn");
        tool = GameObject.FindWithTag("tool");
        cam = GameObject.FindWithTag("MainCamera");
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        pivotPoint = transform.Find("PivotPoint");
        toolYScale = tool.transform.localScale.y;
    }
    
    private void Update()
    {
        //turns the pivotPoint to where the cursor is
        var diraction = Input.mousePosition - Camera.main.WorldToScreenPoint(pivotPoint.position);
        var angle = Mathf.Atan2(diraction.y, diraction.x) * Mathf.Rad2Deg;
        pivotPoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        #region Player and tool turn
        //moves the gun behind the player when it gets to a certain degree
        if (pivotPoint.eulerAngles.z >= 10 && pivotPoint.eulerAngles.z <= 150)
            tool.GetComponent<SpriteRenderer>().sortingOrder = 0;
        else
            tool.GetComponent<SpriteRenderer>().sortingOrder = 1;
        //turns the gun and the player around when it gets to a certain degree
        if (pivotPoint.eulerAngles.z >= 90 && pivotPoint.eulerAngles.z <= 270)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            if (!turn)
            {
                tool.transform.transform.localScale = new Vector3(tool.transform.localScale.x, -tool.transform.localScale.y, tool.transform.localScale.z);
                turn = true;
            }
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            if (turn)
            {
                tool.transform.transform.localScale = new Vector3(tool.transform.localScale.x, -tool.transform.localScale.y, tool.transform.localScale.z);
                turn = false;
            }
        }
        #endregion
        #region Tool Input
        //sets the using bool in the tool to true so it can be used
        if (Input.GetMouseButtonDown(0))
            tool.SendMessage("SetPrimaryUse", true);
        if (Input.GetMouseButtonUp(0))
            tool.SendMessage("SetPrimaryUse", false);

        if (Input.GetMouseButtonDown(1))
            tool.SendMessage("SetSecondaryUse", true);
        if (Input.GetMouseButtonUp(1))
            tool.SendMessage("SetSecondaryUse", false);
        #endregion
        #region Animations
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)//checks if the player is moving
        {
            //if the player is moving it player the waking animation
            anim.SetBool("walking", true);
            anim.SetBool("idle", false);
        }
        else
        {
            //if the player is standing still it player the idle animation
            anim.SetBool("walking", false);
            anim.SetBool("idle", true);
        }
        #endregion
    }

    private void FixedUpdate()
    {
        //moves the player
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        move = input.normalized * moveSpeed;
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
    }
}