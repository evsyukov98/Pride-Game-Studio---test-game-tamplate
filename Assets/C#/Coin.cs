using UnityEngine;

public class Coin : MonoBehaviour, IInteractive
{
    public void Identify()
    {
    }

    public void PickUp()
    {
        Debug.Log("Take money");

        GameManager.instance.CoinsCount++;

        GameManager.instance.AllItemCount--;

        Destroy(this.gameObject);
    }
}
