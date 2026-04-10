using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
            Debug.Log("Everything is looking good");
            break;
            case "Finish":
            Debug.Log("You're all done");
            break;
            case "Fuel":
            Debug.Log("Sorry I don't have any");
            break;
            default:
            Debug.Log("Your crashed dummy");
            break; 
        }
    }
}
