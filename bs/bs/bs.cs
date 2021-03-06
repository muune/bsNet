﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace com.bsidesoft.cs {
    public partial class bs{
        private static ConcurrentDictionary<string, object> _S = new ConcurrentDictionary<string, object>();
        public T S<T>(params object[] kv) {
            var r = SS(kv);
            return r == null ? default(T) : (T)r;
        }
        public object S(params object[] kv) {
            return SS(kv);
        }
        private static object SS(object[] kv) {
            object v = null, n;
            for(var i = 0; i < kv.Length;) {
                string k = (string)kv[i++];
                if(i == kv.Length) {
                    _S.TryGetValue(k, out n);
                    return n;
                }
                v = kv[i++];
                if(v == null) _S.TryRemove(k, out n);
                _S.TryAdd(k, v);
            }
            return v;
        }
        private ConcurrentDictionary<string, object> _s = new ConcurrentDictionary<string, object>();
        public T s<T>(params object[] kv) {
            var r = ss(kv);
            return r == null ? default(T) : (T)r;
        }
        public object s(params object[] kv) {
            return ss(kv);
        }
        private object ss(object[] kv) {
            object v = null, n;
            for(var i = 0; i < kv.Length;) {
                string k = (string)kv[i++];
                if(i == kv.Length) {
                    _s.TryGetValue(k, out n);
                    return n;
                }
                v = kv[i++];
                if(v == null) _s.TryRemove(k, out n);
                _s.TryAdd(k, v);
            }
            return v;
        }
        public bs(ILogger<bs> logger, IHostingEnvironment env) {
            config(logger, env);
        }
    }
}
