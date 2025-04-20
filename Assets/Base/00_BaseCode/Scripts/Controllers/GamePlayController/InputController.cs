using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public void Init()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        if (GamePlayController.Instance.gameScene.IsMouseClickingOnImage)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0)) // Chuột trái
        {
           
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                if(hit.collider.gameObject.GetComponent<ObjInGame>() != null)
                {
                    hit.collider.gameObject.GetComponent<ObjInGame>().HandlShowBox();
                }
            }
         
        }
    }
}
