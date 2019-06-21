using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSetter : MonoBehaviour
{
    [SerializeField] private bool isDungeon = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(!isDungeon)
        {
            if (collision.transform.tag == "Player" || collision.transform.tag == "enemy")
            {
                if (this.transform.tag == "WallFront")
                {
                    collision.GetComponent<SpriteRenderer>().sortingOrder = 12;
                }
                else if (this.transform.tag == "WallBack")
                {
                    collision.GetComponent<SpriteRenderer>().sortingOrder = -12;
                }
            }   
        }
        else
        {
            if (this.transform.tag == "WallFront")
            {
                this.transform.parent.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            else if (this.transform.tag == "WallBack")
            {
                this.transform.parent.GetComponent<SpriteRenderer>().sortingOrder = 4;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isDungeon)
        {
            if (collision.transform.tag == "Player" || collision.transform.tag == "enemy")
            {
                collision.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
        }
        else
        {

        }
    }
}

