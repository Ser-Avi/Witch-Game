using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.U2D;
using UnityEngine.UIElements;

public class Ingredient : MonoBehaviour
{
    [SerializeField] bool isMouseOver = false;
    [SerializeField] float cauldronAddingOffset = 0.2f;
    private Renderer rend;
    private Color startColor;
    private UnityEngine.Vector3 mousePos;
    private UnityEngine.Vector3 cornerA;
    private UnityEngine.Vector3 cornerB;
    private UnityEngine.Vector3[] points;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();

        startColor = rend.material.color;

        points = new UnityEngine.Vector3[2] { cornerA, cornerB };
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        if (isMouseOver)
        {
            MoveManager();
        }
    }

    void MoveManager()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -0.1f;

        if (Input.GetMouseButton(0))
        {
            transform.position = mousePos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            ReleaseManager();
        }
    }

    void ReleaseManager()
    {
        Debug.Log("released");
        cornerA = mousePos + new UnityEngine.Vector3(-cauldronAddingOffset, -cauldronAddingOffset, 0);
        cornerB = mousePos + new UnityEngine.Vector3(cauldronAddingOffset, cauldronAddingOffset, 0);
        //Debug.Log(cornerA);
        Debug.Log(mousePos);
        //Debug.Log(cornerB);
        Collider2D[] overlap = Physics2D.OverlapAreaAll(cornerA, cornerB);
        if (overlap.Length>1 && overlap[1].gameObject.CompareTag("Cauldron"))
        {
            Debug.Log("Item added");
        }
        else if (overlap.Length>1)
        {
            Debug.Log(overlap[1].gameObject.name);
        }
    }

    void OnMouseEnter()
    {
        isMouseOver = true;
        rend.material.color = Color.red;

    }

    void OnMouseExit()
    {
        isMouseOver = false;
        rend.material.color = startColor;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLineStrip(points, true);
    }
}
