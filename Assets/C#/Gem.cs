using UnityEngine;

public class Gem : MonoBehaviour, IInteractive
{
    public void Identify()
    {
        
    }

    public void PickUp()
    {
        GameManager.instance.Exp +=100;

        GameManager.instance.AllItemCount--;

        Destroy(this.gameObject);
    }
}
