using System;

namespace SSSRegen.Source.Game.Notifications
{
    class ActionOnDisposeAdapter : IDisposable
    {
        private Action _action;
        private static readonly Action NullAction = () => { };

        /// <summary>
        /// Wraps a cleanup action that is executed when the object is disposed. For example, unsubscribing from events, or unloading content.
        /// </summary>
        /// <param name="action"></param>
        public ActionOnDisposeAdapter(Action action)
        {
            _action = action ?? throw new ArgumentNullException(nameof(action));
        }

        public void Dispose()
        {
            _action();
            _action = NullAction;
        }
    }
}