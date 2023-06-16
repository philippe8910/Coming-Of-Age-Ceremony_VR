using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using Sirenix.OdinInspector;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Grabbable), typeof(PointableUnityEventWrapper) , typeof(HandGrabInteractable))]
public class CustomOVRGrabbable : MonoBehaviour
{
    [TitleGroup("Setting")]
    [SerializeField] private bool useGravity = false;
    
    [TitleGroup("Require Component")]
    [SerializeField] private Rigidbody rigidbody;

    [TitleGroup("Grab Events")]
    public UnityEvent OnHandGrab;

    public UnityEvent OnHandRelease;

    [TitleGroup("Hover Events")] 
    public UnityEvent OnHoverEvent;

    public UnityEvent OnUnhoverEvent;
    
    private void Awake()
    {
        rigidbody.isKinematic = true;
        rigidbody.useGravity = false;

        TryGetComponent<PointableUnityEventWrapper>(out var events);

        events.WhenSelect.AddListener(OnHandGrab.Invoke);
        events.WhenUnselect.AddListener(OnHandRelease.Invoke);
        
        events.WhenHover.AddListener(OnHoverEvent.Invoke);
        events.WhenUnhover.AddListener(OnUnhoverEvent.Invoke);

        if (useGravity)
        {
            rigidbody.useGravity = true;
            
            events.WhenSelect.AddListener(delegate
            {
                rigidbody.useGravity = false;
                rigidbody.velocity = Vector3.zero;
            });
            
            events.WhenUnselect.AddListener(delegate
            {
                rigidbody.useGravity = true;
                rigidbody.velocity = Vector3.zero;
            });
        }
    }
    
    
}
