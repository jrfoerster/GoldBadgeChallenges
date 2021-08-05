using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims.Repository
{
    public class ClaimsRepository
    {
        private readonly Queue<Claim> _claims = new Queue<Claim>();

        public int Count => _claims.Count;

        public void Add(Claim claim)
        {
            _claims.Enqueue(claim);
        }

        public Claim SeeNextClaim()
        {
            return _claims.Peek();
        }

        public Claim HandleNextClaim()
        {
            return _claims.Dequeue();
        }

        public IEnumerable<Claim> GetAll()
        {
            return _claims;
        }
    }
}
