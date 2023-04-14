using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    //List of placeable objects
    public List<GameObject> objects;
    public int maxObjects = 10;
    public int currentObjects = 0;
    public List<Color> colours;
    public List<string> colourNames;
    void Start()
    {
        colours = new List<Color>();
        colours.Add(Color.red);
        colours.Add(Color.blue);
        colours.Add(Color.green);
        colours.Add(Color.yellow);
        colours.Add(Color.cyan);
        colours.Add(Color.magenta);
        colours.Add(Color.white);
        colours.Add(Color.black);
        colours.Add(Color.gray);

        colourNames = new List<string>();
        colourNames.Add("Red");
        colourNames.Add("Blue");
        colourNames.Add("Green");
        colourNames.Add("Yellow");
        colourNames.Add("Cyan");
        colourNames.Add("Magenta");
        colourNames.Add("White");
        colourNames.Add("Black");
        colourNames.Add("Gray");
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaceObject();
        }
        if(Input.GetMouseButtonDown(1))
        {
            RemoveObject();
        }
        //Holding the middle click will move the object
        if (Input.GetMouseButton(2))
        {
            MoveObject();
        }
        //Change the object to place
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeObject();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeColor();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            RecolorObject();
        }
        if (Input.GetKey(KeyCode.O))
        {
            ScaleObject();
        }
        if(Input.GetKey(KeyCode.L))
        {
           DescaleObject();
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            RotateObject();
        }
    }

    void PlaceObject()
    {
        //Shoot out a ray from where the player is looking
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit) && currentObjects < maxObjects)
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            Debug.Log("hit");
            //If the ray hits the ground, place the cube
            if(hit.collider.gameObject.tag == "ground")
            {
                //Instatiate cube .5 up ont y axis to be placed ontop of the ground
                Instantiate(objects[0], hit.point + objects[0].transform.position, objects[0].transform.rotation);
                currentObjects++;
            }
            if(hit.collider.gameObject.tag == "placedObj")
            {
                Instantiate(objects[0], hit.point, objects[0].transform.rotation);
                currentObjects++;
            }
        }
    }
    void RemoveObject()
    {
        //Shoot out a ray from where the player is looking
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("hit");
            //If the ray hits the ground, place the cube
            if (hit.collider.gameObject.tag == "placedObj")
            {
                //Remove the object
                Destroy(hit.collider.gameObject);
                currentObjects--;
            }
        }
    }
    void ChangeObject()
    {
        //Remove the first object from the list and add it to the end
        objects.Add(objects[0]);
        objects.RemoveAt(0);
    }
    void ChangeColor()
    {
        colours.Add(colours[0]);
        colours.RemoveAt(0);
        colourNames.Add(colourNames[0]);
        colourNames.RemoveAt(0);
    }
    void RecolorObject()
    {
        //Shoot out a ray from where the player is looking
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //If the ray hits a placed object, change the colour
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "placedObj")
            {
                hit.collider.gameObject.GetComponent<Renderer>().material.color = colours[0];
            }

        }
    }
    void MoveObject()
    {
        //Shoot out a ray from where the player is looking
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //If the ray hits a placed object, make the object follow the mouse
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "placedObj")
            {
                hit.collider.gameObject.transform.position = Vector3.Lerp(hit.collider.gameObject.transform.position, hit.point, Time.fixedDeltaTime * 1f);
            }

        }
        
    }
    void ScaleObject()
    {
        //Shoot out a ray from where the player is looking
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //If the ray hits a placed object, make the object follow the mouse
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "placedObj")
            {
                hit.collider.gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
            }

        }
    }
    void DescaleObject()
    {
        //Shoot out a ray from where the player is looking
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //If the ray hits a placed object, make the object follow the mouse
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "placedObj")
            {
                hit.collider.gameObject.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
            }

        }
    }
    void RotateObject()
    {
        //Shoot out a ray from where the player is looking
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //If the ray hits a placed object, make the object follow the mouse
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "placedObj")
            {
                hit.collider.gameObject.transform.Rotate(0, 45f, 0);
            }

        }
    }
}
