using Services.Windows;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Animator))]
public class Chest : MonoBehaviour
{
    private static readonly int Open = Animator.StringToHash("Open");
    
    private IWindowService _windowService;
    private Animator _animator;

    [Inject]
    private void Construct(IWindowService windowService) =>
        _windowService = windowService;
    
    public void Awake() =>
        _animator = GetComponent<Animator>();

    public void OnOpenedChest()
    {
        _windowService.Open(WindowId.Gear);
    }

    public void OpenChest() =>
        _animator.SetTrigger(Open);
}