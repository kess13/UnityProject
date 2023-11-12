using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    
    [SerializeField] KeyCode keyTwo;
    [SerializeField] KeyCode keyOne;
    [SerializeField] Vector3 MoveDirection;
    private void FixedUpdate()
    {
        if (Input.GetKey(keyOne)) 
        {
            GetComponent<Rigidbody>().velocity += MoveDirection;
        }
        if (Input.GetKey(keyTwo))
        {
            GetComponent<Rigidbody>().velocity -= MoveDirection;
        }
        if (Input .GetKey(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }



    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player")&& other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (this.CompareTag("Cube") && other.CompareTag("Cube")) //if one cube touches another
        {
            foreach (Button button in FindObjectsOfType<Button>())
            {
                button.CanPush = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (this.CompareTag("Cube") && other.CompareTag("Cube")) //if one cube touches another
        {
            foreach (Button button in FindObjectsOfType<Button>())//for all buttons push false
            {
                button.CanPush = true;
            }
        }
    }
}
