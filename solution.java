public void subscribe(String event, Consumer<Object> listener) {
        if (!listeners.containsKey(event)) {
            listeners.put(event, new ArrayList<>());
        }
        listeners.get(event).add(listener);
    }