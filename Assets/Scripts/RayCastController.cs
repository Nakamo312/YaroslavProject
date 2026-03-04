using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastController : MonoBehaviour
{
    public PlayerControls actions;
    public Camera camera;
    void Start()
    {
        actions = new PlayerControls();
    }

    void OnEnable()
    {
        actions.Player.Enable();
        actions.Player.Interact.performed += OnInteractedPerformed;

    }

    void OnInteractedPerformed(InputAction.CallbackContext context)
    {

    }

    void Update()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("Interactable"))
            {
                Destroy(hitObject);
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
    }
}
