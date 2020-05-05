using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlassProject.Models
{
    public class Product
    {
        public int Pid { get; set; }
        public string PProductName { get; set; }
        public string Plength { get; set; }
        public string Pbreadth { get; set; }
        public string Ppolish { get; set; }
        public string PTotalPrice { get; set; }
        public string PMail { get; set; }
        public string Pmobileno { get; set; }
        public string PUserName { get; set; }
        public string PSqft { get; set; }

        public string PBuildingNo { get; set; }
        public string PLandMark { get; set; }
        public string PState { get; set; }
        public string PCity { get; set; }
        public string PPincode { get; set; }
        [DataType(DataType.Text)]
        public string POrderImage { get; set; }
        public string PProductType { get; set; }




    }
}