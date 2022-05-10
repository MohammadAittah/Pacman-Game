using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostHome : GhostBehavior
{
    public Transform inside;
    public Transform outside;


    private void OnEnable()
    {
        StopAllCoroutines();    
    }

    private void OnDisable()
    {
        if (this.gameObject.activeSelf)
        {
            //To call function every frame
            StartCoroutine(ExitTransition());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Ghost Home idle movement 
        if (this.enabled && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            this.ghost.movement.SetDirection(-this.ghost.movement.direction);
        }
    }

    private IEnumerator ExitTransition()
    {
        //Disable physics and force direction upwards
        this.ghost.movement.SetDirection(Vector2.up, true);
        this.ghost.movement.rigidbody.isKinematic = true;
        this.ghost.movement.enabled = false;

        Vector3 position = this.transform.position;

        float duration = 0.5f;
        float elapsed = 0.0f;

        //Change position smoothly using Lerp function from current position to the middle of Home
        while (elapsed<duration)
        {
            Vector3 newPosition = position;
            newPosition = Vector3.Lerp(position, this.inside.position , elapsed / duration);
            newPosition.z = position.z;
            this.ghost.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0.0f;

        //Change position smoothly using Lerp function from middle of Home to Outside of Home
        while (elapsed < duration)
        {
            Vector3 newPosition = position;
            newPosition = Vector3.Lerp(this.inside.position, this.outside.position, elapsed / duration);
            newPosition.z = position.z;
            this.ghost.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        //Set random intial direction and reenable physics
        this.ghost.movement.SetDirection(new Vector2(Random.value <0.5f ? -1.0f : 1.0f , 0.0f), true);
        this.ghost.movement.rigidbody.isKinematic = false;
        this.ghost.movement.enabled = true;
    }
}
