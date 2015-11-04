﻿using System.ComponentModel;

namespace INotify.EventArguments
{
    public class ReactToPropertyEventArgs : PropertyChangedEventArgs
    {
        public ReactToPropertyEventArgs(long session, string propertyName)
            : base(propertyName)
        {
            Session = session;
        }

        public long Session { get; internal set; }
    }
}
