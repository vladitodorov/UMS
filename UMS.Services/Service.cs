namespace UMS.Services
{
    using System;
    using UMS.Data;

    public abstract class Service
    {
        protected UmsDbContext Context { get; }

        public Service()
        {
            this.Context = new UmsDbContext();
        }
    }
}
