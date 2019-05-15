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
    private Transform gunPivotPoint;
    private Vector2 move;
    private Vector3 mousePosition;
    private Vector3 previousPlayerPosition;
    private Vector3 currentPlayerPosition;
    private float toolYScale;
    private bool turn = false;
    #endregion

    private void Start()
    {
        spawner = GameObject.FindWithTag("PlayerBulletSpawn");
        tool = GameObject.FindWithTag("tool");
        cursor = GameObject.FindWithTag("Cursor");
        cam = GameObject.FindWithTag("MainCamera");
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        gunPivotPoint = transform.Find("GunPivotPoint");
        previousPlayerPosition = this.transform.position;
        currentPlayerPosition = this.transform.position;
        toolYScale = tool.transform.localScale.y;
    }
    
    private void Update()
    {
        var diraction = Input.mousePosition - Camera.main.WorldToScreenPoint(gunPivotPoint.position);
        var angle = Mathf.Atan2(diraction.y, diraction.x) * Mathf.Rad2Deg;
        gunPivotPoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        #region Player and tool turn
        if (gunPivotPoint.eulerAngles.z >= 10 && gunPivotPoint.eulerAngles.z <= 150)
            tool.GetComponent<SpriteRenderer>().sortingOrder = 0;
        else
            tool.GetComponent<SpriteRenderer>().sortingOrder = 1;
        
        if(gunPivotPoint.eulerAngles.z >= 90 && gunPivotPoint.eulerAngles.z <= 270)
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
        if (Input.GetMouseButtonDown(0))
            tool.SendMessage("SetPrimaryUse", true);
        if (Input.GetMouseButtonUp(0))
            tool.SendMessage("SetPrimaryUse", false);
        #endregion
        #region Camera Movement
        
        #endregion
        #region Animations
        if (previousPlayerPosition != currentPlayerPosition)//checks if the player is moving
        {
            //if the player is moving it player the waking animation
            anim.SetBool("walking", true);
            //anim.SetBool("idle", false);
        }
        else
        {
            //if the player is standing still it player the idle animation
            anim.SetBool("walking", false);
            //anim.SetBool("idle", true);
        }
        previousPlayerPosition = currentPlayerPosition;
        currentPlayerPosition = this.transform.position;
        #endregion
    }

    private void FixedUpdate()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        move = input.normalized * moveSpeed;
        rb.MovePosition(rb.position + move * Time.fixedDeltaTime);
    }
}