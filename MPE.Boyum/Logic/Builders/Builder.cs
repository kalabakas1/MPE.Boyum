using System;
using System.Collections.Generic;
using System.Reflection;

namespace MPE.Boyum.Logic.Builders
{
    namespace MPE.SS.Logic.Builders
    {
        internal class Builder<T> 
        {
            private List<Action<T>> _actions;

            public Builder()
            {
                _actions = new List<Action<T>>();
            }

            public Builder<T> Where(Action<T> action)
            {
                _actions.Add(action);
                return this;
            }

            public T Build()
            {
                var obj = (T)Activator.CreateInstance(typeof(T), BindingFlags.Public | BindingFlags.Default | BindingFlags.NonPublic | BindingFlags.Instance, null, new object[] { }, null);
                foreach (var action in _actions)
                {
                    action.Invoke(obj);
                }
                _actions = new List<Action<T>>();
                return obj;
            }
        }
    }

}
