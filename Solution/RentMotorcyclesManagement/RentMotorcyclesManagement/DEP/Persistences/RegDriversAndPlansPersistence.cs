using System;

namespace RentMotorcyclesManagement
{
    public class RegDriversAndPlansPersistence
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisterDate { get; set; }
        public string PlanDescription { get; set; }
        public DateTime PlanStartDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        public DateTime ExpectedReturnDate { get; set; }
        public double PlanPrice { get; set; }
        public double PlanTax { get; set; }
        public double TotalAmount { get; set; }
    }
}
