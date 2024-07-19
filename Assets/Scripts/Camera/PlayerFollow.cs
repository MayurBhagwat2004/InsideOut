using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField]Transform player;
    [SerializeField]private Vector2 offset;
    void Start()
    {
        offset.y = 2.6f;
    }


    void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer() 
    {
        this.transform.position = new Vector3(player.position.x+offset.x,player.position.y+offset.y,this.transform.position.z);
    }

}
