```java
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.function.Consumer;

public class EventEmitter {
    private Map<String, List<Consumer<Object>>> listeners = new HashMap<>();

    public void subscribe(String event, Consumer<Object> listener) {
        if (!listeners.containsKey(event)) {
            listeners.put(event, new ArrayList<>());
        }
        listeners.get(event).add(listener);
    }

    public void unsubscribe(String event, Consumer<Object> listener) {
        if (listeners.containsKey(event)) {
            listeners.get(event).remove(listener);
        }
    }

    public void emit(String event, Object data) {
        if (listeners.containsKey(event)) {
            for (Consumer<Object> listener : listeners.get(event)) {
                listener.accept(data);
            }
        }
    }

    public static void main(String[] args) {
        EventEmitter emitter = new EventEmitter();
        Consumer<Object> listener1 = data -> System.out.println("Listener 1 received: " + data);
        Consumer<Object> listener2 = data -> System.out.println("Listener 2 received: " + data);

        emitter.subscribe("event1", listener1);
        emitter.subscribe("event1", listener2);
        emitter.subscribe("event2", listener1);

        emitter.emit("event1", "Hello");
        emitter.emit("event2", "World");

        emitter.unsubscribe("event1", listener1);
        emitter.emit("event1", "Hello again");
    }
}
```