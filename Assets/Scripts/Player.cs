using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] public Resources resources;
    [SerializeField] private UnityEvent<Resources> onResourcesChange;
    public Resources Resources => resources;

    private void Start()
    {
        onResourcesChange.Invoke(resources);
    }

    public void AddResources(Resources resources)
    {
        this.resources = resources;
        onResourcesChange.Invoke(this.resources);
    }
}