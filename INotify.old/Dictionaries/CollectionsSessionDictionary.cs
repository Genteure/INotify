﻿using System.Collections.Concurrent;
using INotify.Contracts;
using INotify.EventArguments;

namespace INotify.Dictionaries
{
    sealed class CollectionsSessionDictionary : ConcurrentDictionary<long, CollectionChangesDictionary>
    {
        #region methods

        public void TrackReaction(IReactToCollection collection, ReactToCollectionEventArgs args)
        {
            if (args.Session > 0)
            {
                AddOrUpdate(args.Session,
                            sessionKey =>
                            {
                                var ncd = new CollectionChangesDictionary();
                                ncd.TryAdd(collection, args);

                                return ncd;
                            },
                            (sessionKey, ncd) =>
                            {
                                ncd.TryAdd(collection, args);

                                return ncd;
                            });
            }
        }

        #endregion
    }
}
