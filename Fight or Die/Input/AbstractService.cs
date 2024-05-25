namespace Fight_or_Die.Input;

public abstract class AbstractService : IService
{
    private bool _isEnable = false;
    
    public void Enable()
    {
        if (_isEnable)
            return;

        _isEnable = true;
        OnEnable();
    }

    public void Disable()
    {
        if(!_isEnable)
            return;

        _isEnable = false;
        OnDisable();
    }

    protected abstract void OnEnable();
    protected abstract void OnDisable();
}