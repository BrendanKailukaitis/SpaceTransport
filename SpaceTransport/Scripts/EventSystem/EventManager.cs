using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTransport.Scripts.EventSystem
{
    public class Handler
    {
        public object Target { get; set; }
        public System.Reflection.MethodInfo Method { get; set; }
    }

    public static class EventManager
    {
        private delegate void EventListener(Event e);

        private static Dictionary<Type, List<Handler>> _eventListeners;

        public static void RegisterListener<T>(Action<T> listener) where T : Event
        {
            var target = listener.Target;
            var method = listener.Method;

            // Get type of event.
            Type eventType = typeof(T);

            if (_eventListeners == null)
            {
                _eventListeners = new Dictionary<Type, List<Handler>>();
            }

            if (_eventListeners.ContainsKey(eventType) == false || _eventListeners[eventType] == null)
            {
                _eventListeners[eventType] = new List<Handler>();
            }

            _eventListeners[eventType].Add(new Handler { Target = target, Method = method });
        }

        public static void UnregisterListener<T>(Action<T> listener) where T: Event
        {
            Type eventType = typeof(T);
            _eventListeners[eventType].RemoveAll(l => l.Target == listener.Target && l.Method == listener.Method);
        }

        public static void Invoke(Event e)
        {
            Type eventClass = e.GetType();
            if (_eventListeners?[eventClass] == null)
            {
                // No one is listening, we are done.
                return;
            }

            // Reverse the list 
            List<Handler> listeners = _eventListeners[eventClass];
            listeners.Reverse();

            for (int i = 0; i < listeners.Count; i++)
            {
                // Call each listeners function.
                var l = _eventListeners[eventClass][i];
                l.Method.Invoke(l.Target, new object[] { e });
            }
        }

    }
}
