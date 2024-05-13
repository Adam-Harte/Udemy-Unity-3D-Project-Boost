using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Finish":
                Debug.Log("Congrats you finished!");
                break;
            case "Fuel":
                Debug.Log("You picked up fuel");
                break;
            default:
                Debug.Log("Sorry you blew up!");
                break;
        }
    }
}
