// Author: Fatima Nadeem

using UnityEngine;

public class InputManager : MonoBehaviour
{
    int currentProdNum; // Index of current active product
    int totalProds; // Total number of products
    Transform nextProd; // Index of next product to activate
    Transform prevProd; // Index of previous product to deactivate

    public Transform buttons; // All buttons used to select products
    public float rotationSpeed = 100f; // One rotation speed for all products 

    void Start()
    {
        currentProdNum = 0; // Index of first product
        totalProds = transform.childCount; // Getting total number of products

        // Activating first product in the list and deactivating the rest
        for (int prodNum = 0; prodNum < totalProds; prodNum++)
        {
            if (prodNum == currentProdNum)
            {
                nextProd = transform.GetChild(prodNum);
                nextProd.gameObject.SetActive(true);
                nextProd.GetComponent<Rotator>().AllowRotate(true);
                buttons.GetChild(prodNum).GetChild(0).GetComponent<Rotator>().
                    AllowRotate(true);
            }
            else
            {
                nextProd = transform.GetChild(prodNum);
                nextProd.gameObject.SetActive(false);
                nextProd.GetComponent<Rotator>().AllowRotate(false);
                buttons.GetChild(prodNum).GetChild(0).GetComponent<Rotator>().
                    AllowRotate(false);
            }
        }
    }

    private void Update()
    {
        // Quitting application if back button is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void View(int prodIdx)
    /* 
        This function activates (the viewing and rotation) of the selected 
        product, as well as the simultaneous rotation of its button (and 
        deactivates the same for the rest of the products).

        Input: Index of the product selected using its button
    */
    {
        if (currentProdNum != prodIdx) // If the selected product is not already
                                       // active
        {
            nextProd = transform.GetChild(prodIdx);
            nextProd.gameObject.SetActive(true);
            nextProd.GetComponent<Rotator>().AllowRotate(true);
            buttons.GetChild(prodIdx).GetChild(0).GetComponent<Rotator>().
                    AllowRotate(true);


            prevProd = transform.GetChild(currentProdNum);
            prevProd.gameObject.SetActive(false);
            buttons.GetChild(currentProdNum).GetChild(0).GetComponent<Rotator>().
                    AllowRotate(false);

            currentProdNum = prodIdx; // Updating current active product index
        }
    }
}
