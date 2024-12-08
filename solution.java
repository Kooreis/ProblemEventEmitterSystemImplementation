import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.function.Consumer;

public class EventEmitter {
    private Map<String, List<Consumer<Object>>> listeners = new HashMap<>();
}