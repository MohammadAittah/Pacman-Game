using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScatter : GhostBehavior
{
    //Enable Chase when disabling scatter
    private void OnDisable()
    {
        this.ghost.chase.Enable();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();

        if(node != null && this.enabled && !this.ghost.frightened.enabled)
        {
            //Get random Direction to pick
            
            int index = Random.Range(0, node.avalilableDirections.Count);

            //To Prevent Ghost from going back to last node he went to

            if(node.avalilableDirections[index] == -ghost.movement.direction && node.avalilableDirections.Count >1)
            {
                index++;
                
                //Overflow Prevention
                if(index >= node.avalilableDirections.Count)
                {
                    index = 0;
                }
            }

            //Set the ghost direction
            this.ghost.movement.SetDirection(node.avalilableDirections[index]);
        }
    }
}
