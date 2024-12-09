```csharp
public void Subscribe(string eventName, Action handler)
{
    if (!events.ContainsKey(eventName))
    {
        events[eventName] = null;
    }
    events[eventName] += handler;
}

public void Unsubscribe(string eventName, Action handler)
{
    if (events.ContainsKey(eventName))
    {
        events[eventName] -= handler;
    }
}
```