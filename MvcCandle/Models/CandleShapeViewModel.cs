using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcCandle.Models
{
    public class CandleShapeViewModel
    {
        public List<Candle> Candles { get; set; }
        public SelectList Shapes { get; set; }
        public string CandleShape { get; set; }
        public string SearchString { get; set; }

    }
}
