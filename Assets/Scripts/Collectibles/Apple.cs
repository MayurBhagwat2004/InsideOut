using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [SerializeField]private Animator appleAnimator;
    public bool playerCollided;

    void Start()
    {
        appleAnimator  = GetComponent<Animator>();
    }

    void Update()
    {
        animate();
    }

    private void animate() 
    {
        if (playerCollided) 
        {
            StartCoroutine(DestroyApple());
        }
        else
        {
            appleAnimator.SetBool("Idle", true);
            appleAnimator.SetBool("Destroy", false);
        }
    }

    private IEnumerator DestroyApple() 
    {
        appleAnimator.SetBool("Idle", false);
        appleAnimator.SetBool("Destroy", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player") 
        {
            playerCollided = true;
            CollectiblesManager.instance.AppleCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCollided = false;
        }
    }
}
