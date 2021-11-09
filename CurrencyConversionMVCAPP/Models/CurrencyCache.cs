using CurrencyConversionMVCAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConversionMVCAPP.Models
{
    public static class CurrencyCache
    {
        //public static Dictionary<int, CurrencyResultViewModel> _cache;
        //static CurrencyCache()
        //{
        //    _cache = new Dictionary<int, CurrencyResultViewModel>();
        //}
        //public static void Add(CurrencyResultViewModel model)
        //{
        //    if (_cache.Count >= 5)
        //    {
        //        _cache.Remove(1);

        //        for(var i=2;i<=_cache.Count;i++)
        //        {
        //            var result;
        //            var output = _cache.TryGetValue(i, out result);
        //        }
        //        foreach(var x in _cache)
        //        {
        //            CurrencyResultViewModel obj = x.Value;
        //            _cache.Remove(c);
        //            _cache.Add(c - 1, obj);

        //        }
        //        _cache.Add(5, model);
        //    }
        //    else
        //    {
        //        _cache.Add(_cache.Count + 1, model);
        //    }
        //}
        public static Queue<CurrencyResultViewModel> currency;
        static CurrencyCache()
        {
            currency = new Queue<CurrencyResultViewModel>();
        }
        public static void Add(CurrencyResultViewModel model)
        {
            if(currency.Count>=5)
            {
                currency.Dequeue();
                currency.Enqueue(model);
            }
            else
            {
                currency.Enqueue(model);
            }
        }

    }
}
