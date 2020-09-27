using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    void Update()
    {
        GameManager.instance.IsItemDetected = CheckItem();

        if (InputManager.TakeInput())
        {
            TakeItem();
        }
    }

    public void TakeItem()
    {
        if (GameManager.instance.IsItemDetected)
        {
            Collider[] collisions = Physics.OverlapSphere(transform.position, 1f);

            foreach (Collider collided in collisions)
            {
                if (collided.gameObject.tag == "Item")
                {
                    collided.gameObject.GetComponent<IInteractive>().PickUp();
                }
            }
        }  
    }

    /// <summary>
    /// Проверить есть ли рядом предметы
    /// </summary>
    /// <returns>Если есть = true ? false</returns>
    private bool CheckItem()
    {
        Collider[] collisions = Physics.OverlapSphere(transform.position, 1f);

        if (collisions.Length > 0)
        {
            foreach (Collider collided in collisions)
            {
                if (collided.gameObject.tag == "Item")
                {
                    return true;
                }
            }
        }
        return false;
    }
}
