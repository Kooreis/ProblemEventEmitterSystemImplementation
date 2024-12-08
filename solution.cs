```csharp
using System;
using System.Collections.Generic;

public class EventEmitter
{
    private Dictionary<string, Action> events = new Dictionary<string, Action>();
}
```