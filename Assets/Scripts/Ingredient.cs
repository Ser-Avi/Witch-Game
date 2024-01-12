using UnityEngine;

public class Ingredient : MonoBehaviour
{
    Vector2 startPos;

    //Temp test vars
    private Renderer rend;
    private Color startColor;

    //Dragging
    bool isMouseOver = false;
    bool isDragging = false;
    private Vector3 mousePos;
    private Vector3 cornerA;
    private Vector3 cornerB;
    [SerializeField] float cauldronAddingOffset = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMouseOver)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = -0.1f;
            ClickManager();
            if (isDragging)
            {
                //transform.Translate(mousePos);
                transform.position = mousePos;
            }
        }
    }

    void ClickManager()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            CauldronChecker();
        }
    }

    void CauldronChecker()
    {
        cornerA = mousePos + new UnityEngine.Vector3(-cauldronAddingOffset, -cauldronAddingOffset, 0);
        cornerB = mousePos + new UnityEngine.Vector3(cauldronAddingOffset, cauldronAddingOffset, 0);
        Collider2D[] overlap = Physics2D.OverlapAreaAll(cornerA, cornerB);
        if (overlap.Length > 1 && overlap[1].gameObject.CompareTag("Cauldron"))
        {
            Debug.Log("Item added");
        }
        else if (overlap.Length > 1)
        {
            Debug.Log(overlap[1].gameObject.name);
            Debug.Log("Uh oh");
        }
        else
        {
            transform.position = startPos;
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
        isDragging = false;
        CauldronChecker();
        rend.material.color = startColor;
    }
}
