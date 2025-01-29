using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bandysharp.Collections
{
    public class LigmaPair<TMain, TSub>
    {
        public TMain main;
        public TSub sub;

        public static implicit operator TMain(LigmaPair<TMain, TSub> pair)
        {
            return pair.main;
        }
        public LigmaPair<TMain, TSub> GetPair()
        {
            return this;
        }
        public LigmaPair(TMain m, TSub s)
        {
            main = m;
            sub = s;
        }
    
    }
    public class LigmaMap<TMain, TSub>
    {
        public List<LigmaPair<TMain, TSub>> pairs = new List<LigmaPair<TMain, TSub>>();
        public LigmaPair<TMain, TSub> this[int index]
        {
            get
            {
                return pairs[index];
            }
            set
            {
                pairs[index] = value;  
            }
        }
        public void Add(LigmaPair<TMain, TSub> pair) => pairs.Add(pair);

        public void Add(TMain main, TSub sub) => pairs.Add(new LigmaPair<TMain, TSub>(main, sub));
        //yes
        public void Add(TMain main) => pairs.Add(new LigmaPair<TMain, TSub>(main, default(TSub)));

        public void Swap(int index1, int index2)
        {
            var f = this[index1];
            this[index1] = this[index2];
            this[index2] = f;
        }
    }

}
