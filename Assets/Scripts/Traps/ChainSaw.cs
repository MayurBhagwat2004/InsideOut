    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ChainSaw : MonoBehaviour
    {
        [SerializeField]private Transform point1;
        [SerializeField]private Transform point2;
        public bool reachedPoint1;
        public bool reachedPoint2;
        [SerializeField]private float speed;
        void Start()
        {
            speed = 5f;
            reachedPoint1 = false;
            reachedPoint2 = true;
      
        }

        void Update()
        {
            Move(point1,point2);
        }

        private void Move(Transform point1,Transform point2)
    {
        if (!reachedPoint1 && reachedPoint2)
        {
            transform.position = Vector2.MoveTowards(transform.position, point1.position, speed * Time.deltaTime);
            
            if (transform.position.x == point1.position.x)
            {
                reachedPoint1 = true;
                reachedPoint2 = false;
            }
        }

        if (reachedPoint1 && !reachedPoint2)
        {
            transform.position = Vector2.MoveTowards(transform.position, point2.position, speed * Time.deltaTime);

            if (transform.position.x == point2.position.x)
            {
                reachedPoint1 = false;
                reachedPoint2 = true;
            }
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag=="Player" && PlayerManager.instance!=null) 
            {
                PlayerManager.instance.playerDied = true;
            }
        }
    }
