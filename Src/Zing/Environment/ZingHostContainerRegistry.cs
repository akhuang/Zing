﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zing.Caching;

namespace Zing.Environment
{
    /// <summary>
    /// Provides ability to connect Shims to the OrchardHostContainer
    /// </summary>
    public static class ZingHostContainerRegistry
    {
        private static readonly IList<Weak<IShim>> _shims = new List<Weak<IShim>>();
        private static IZingHostContainer _hostContainer;
        private static readonly object _syncLock = new object();

        public static void RegisterShim(IShim shim)
        {
            lock (_syncLock)
            {
                CleanupShims();

                _shims.Add(new Weak<IShim>(shim));
                shim.HostContainer = _hostContainer;
            }
        }

        public static void RegisterHostContainer(IZingHostContainer container)
        {
            lock (_syncLock)
            {
                CleanupShims();

                _hostContainer = container;
                RegisterContainerInShims();
            }
        }

        private static void RegisterContainerInShims()
        {
            foreach (var shim in _shims)
            {
                var target = shim.Target;
                if (target != null)
                {
                    target.HostContainer = _hostContainer;
                }
            }
        }

        private static void CleanupShims()
        {
            for (int i = _shims.Count - 1; i >= 0; i--)
            {
                if (_shims[i].Target == null)
                    _shims.RemoveAt(i);
            }
        }
    }
}
