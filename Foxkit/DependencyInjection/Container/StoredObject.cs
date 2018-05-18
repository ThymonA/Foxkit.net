namespace Foxkit
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class StoredObject
    {
        public Type Type { get; set; }

        public ContainerType ContainerType { get; set; }

        public List<ParameterInfo> Parameters { get; set; }

        public object CurrentContent { get; set; }

        public Func<object> GetObject { get; set; }
    }
}
