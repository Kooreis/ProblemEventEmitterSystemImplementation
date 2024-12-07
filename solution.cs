Here is a simple implementation of an event emitter system in C#:

```csharp
using System;
using System.Collections.Generic;

public class EventEmitter
{
    private Dictionary<string, Action> events = new Dictionary<string, Action>();

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

    public void Emit(string eventName)
    {
        if (events.ContainsKey(eventName))
        {
            events[eventName]?.Invoke();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        EventEmitter eventEmitter = new EventEmitter();

        Action handler1 = () => Console.WriteLine("Handler 1 executed");
        Action handler2 = () => Console.WriteLine("Handler 2 executed");

        eventEmitter.Subscribe("event1", handler1);
        eventEmitter.Subscribe("event1", handler2);

        eventEmitter.Emit("event1");

        eventEmitter.Unsubscribe("event1", handler1);

        eventEmitter.Emit("event1");

        Console.ReadKey();
    }
}
```

In this code, the `EventEmitter` class is responsible for managing the subscriptions and emitting the events. The `Subscribe` method is used to add a handler to an event, the `Unsubscribe` method is used to remove a handler from an event, and the `Emit` method is used to trigger all handlers associated with an event. The `Main` method in the `Program` class demonstrates how to use the `EventEmitter` class.