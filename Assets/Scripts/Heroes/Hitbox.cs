using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private bool bossInside = false;

    public bool IsBossInside()
    {
        return bossInside;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Demon")
        {
            bossInside = true;
            //Debug.Log("Boss entered hitbox " + bossInside);
        }

        //Debug.Log("#Boss entered hitbox | Hitbox ID: " + GetInstanceID());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Demon")
        {
            bossInside = false;

            //Debug.Log("Boss left hitbox " + bossInside);
        }
    }
}
