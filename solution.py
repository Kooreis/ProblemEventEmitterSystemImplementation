```python
class EventEmitter:
    def __init__(self):
        self.subscribers = {}

    def subscribe(self, event, callback):
        if event not in self.subscribers:
            self.subscribers[event] = []
        self.subscribers[event].append(callback)

    def unsubscribe(self, event, callback):
        if event in self.subscribers:
            self.subscribers[event].remove(callback)

    def emit(self, event, *args, **kwargs):
        if event in self.subscribers:
            for callback in self.subscribers[event]:
                callback(*args, **kwargs)


def test_callback(*args, **kwargs):
    print(f"Event triggered with arguments {args} and keyword arguments {kwargs}")


if __name__ == "__main__":
    emitter = EventEmitter()
    emitter.subscribe("test", test_callback)
    emitter.emit("test", 1, 2, 3, a=4, b=5)
    emitter.unsubscribe("test", test_callback)
    emitter.emit("test", 1, 2, 3, a=4, b=5)
```