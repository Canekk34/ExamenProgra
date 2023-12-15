  using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] private Transform rayOrigin;
    [SerializeField] private float interactionRange;
    [SerializeField] private LayerMask interactionMask;

    private Inventory inventory;

    Ray ray;
    RaycastHit hit;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        InteractionRay();
    }

    private void InteractionRay()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, interactionRange, interactionMask))
        {

            if (Input.GetMouseButtonDown(0))
            {

                switch (hit.collider.tag)
                {

                    case "Interactable":
                        {
                            
                            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                            
                            if(interactable._requireInventory)
                            {
                                interactable.Interact(inventory);
                            }
                            else
                            {
                                interactable.Interact();
                            }
                            
                            break;
                        }

                    case "Recollectable":
                        {
                            inventory.AddItem(hit.collider.GetComponent<IRecollectable>().Pick());
                            Destroy(hit.collider.gameObject);
                            break;
                        }
                }

            }

        }
    }

    private void OnDrawGizmos()
    {

        Gizmos.DrawRay(ray);

    }


}
