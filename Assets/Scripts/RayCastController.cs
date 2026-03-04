using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCastController : MonoBehaviour
{
    public Camera camera;
    public float raycastDistance = 100f;
    public LayerMask interactableLayer; 
    
    private PlayerInputActions playerInputActions;
    private GameObject currentLookedAtObject; 
    private GameObject previousLookedAtObject;
    
    void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }
    
    void OnEnable()
    {
        playerInputActions.Player.Enable();
        playerInputActions.Player.Interact.performed += OnInteractPerformed;
    }
    
    void OnDisable()
    {
        playerInputActions.Player.Interact.performed -= OnInteractPerformed;
        playerInputActions.Player.Disable();
        
        ResetHighlight();
    }
    
    void Start()
    {
       
    }
    
    void Update()
    {
        PerformRaycast();
        
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(ray.origin, ray.direction * raycastDistance, Color.green);
    }
    
    void PerformRaycast()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, raycastDistance, interactableLayer))
        {
            var hitObject = hit.collider.gameObject;
            
            if (hitObject != currentLookedAtObject)
            {

                ResetHighlight();
                
                currentLookedAtObject = hitObject;
                
                HighlightObject(currentLookedAtObject);
            }
        }
        else
        {
            if (currentLookedAtObject != null)
            {
                ResetHighlight();
            }
        }
    }
    
    void HighlightObject(GameObject obj)
    {
        
        var outline = obj.GetComponent<Outline>();
        if (outline == null)
        {
            outline = obj.AddComponent<Outline>();
            outline.OutlineColor = Color.yellow;
            outline.OutlineWidth = 5f;
        }
        outline.enabled = true;
        
    }
    
    void ResetHighlight()
    {
        if (currentLookedAtObject != null)
        {

            var outline = currentLookedAtObject.GetComponent<Outline>();
            if (outline != null)
            {
                outline.enabled = false;
            }
            

            currentLookedAtObject = null;
        }
    }
    
    void OnInteractPerformed(InputAction.CallbackContext context)
    {
        if (currentLookedAtObject != null && currentLookedAtObject.CompareTag("tEGGG"))
        {
            InteractWithObject(currentLookedAtObject);
        }
    }
    
    void InteractWithObject(GameObject obj)
    {
        Debug.Log($"Взаимодействие с объектом: {obj.name}");

        Destroy(obj);
        
    }
}