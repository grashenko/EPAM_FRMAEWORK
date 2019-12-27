using System;

namespace TestFramework.Environment
{
    internal class MemoryFileInfo
    {
        private string v;
        private object p;
        private DateTimeOffset now;

        public MemoryFileInfo(string v, object p, DateTimeOffset now)
        {
            this.v = v;
            this.p = p;
            this.now = now;
        }
    }
}