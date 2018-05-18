namespace Foxkit
{
    using System;

    public class GpgKey
    {
        public long Id { get; set; }

        public string Key { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
