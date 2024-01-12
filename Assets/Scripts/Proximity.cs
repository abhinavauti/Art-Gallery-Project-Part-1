using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Proximity : MonoBehaviour
{
    public string newTitle;
    public string newAuthor;
    public string newDesc;
    private Transform other;
    private TextMeshProUGUI myTitle;
    private TextMeshProUGUI myAuthor;
    private TextMeshProUGUI myDesc;
    private float dist;
    private GameObject player;
    private GameObject message1;
    private GameObject message2;
    private GameObject message3;
    private bool check;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        other = player.GetComponent<Transform>();
        message1 = GameObject.FindWithTag("ArtTitle");
        message2 = GameObject.FindWithTag("Auth");
        message3 = GameObject.FindWithTag("Description");
        myTitle = message1.GetComponent<TextMeshProUGUI>();
        myTitle.text = "";
        myAuthor = message2.GetComponent<TextMeshProUGUI>();
        myAuthor.text = "";
        myDesc = message3.GetComponent<TextMeshProUGUI>();
        myDesc.text = "";
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (other)
        {
            dist = Vector3.Distance(transform.position, other.position);
            //print("Distance to player: " + dist);
            if (dist < 8)
            {
                myTitle.text = newTitle;
                myAuthor.text = newAuthor;
                myDesc.text = newDesc;
                check = true;
            }
            if (dist > 8 && check == true)
            {
                Start();
            }
        }
    }
}
