using System;
using System.Data;

namespace CurrentProject.model
{
    internal class SqlConnection
    {
        private string v;

        public ConnectionState State { get; internal set; }

        public SqlConnection(string v)
        {
            this.v = v;
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }
    }
}