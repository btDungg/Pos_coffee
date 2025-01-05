using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Coffee.Models
{
    public class PromotionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string discount_type { get; set; }
        public decimal discount_value { get; set; }
        public decimal min_order_value { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public bool is_active { get; set; }
        public string applicable_to { get; set; }
        public DateTime created_date { get; set; }
        public DateTime updated_date { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
    }
}
