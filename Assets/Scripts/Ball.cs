using UnityEngine;

using System.Collections;
using System.Collections.Generic;


public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject splashImg;
    [SerializeField] private float jumpForce;
    private GameManager gm;
    private Ring ring;

    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision other)
    {
        rb.AddForce(Vector3.up * jumpForce);
        GameObject splash = Instantiate(splashImg, transform.position , transform.rotation);
        splash.transform.SetParent(other.gameObject.transform);
        Destroy(splash, 1);

        string metarialName = other.gameObject.GetComponent<MeshRenderer>().material.name;
        if (metarialName == "Unsafe Color (Instance)")
        {
            gm.restartGame();
        }
    }
}