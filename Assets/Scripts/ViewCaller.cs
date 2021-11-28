// Author: Fatima Nadeem

using UnityEngine;

public class ViewCaller : MonoBehaviour
{
    int idx; // Index of this product button - same as the associated product

    public InputManager iM; // Accessing input manager to activate the
                            // associated product on selection

    void Start()
    {
        idx = transform.GetSiblingIndex(); // Getting the index of this
                                           // product button
    }
    public void CallView()
    /*
        This function views the product associated with this button.  
    */
    {
        iM.View(idx); // Activating the associated product
    }
}
